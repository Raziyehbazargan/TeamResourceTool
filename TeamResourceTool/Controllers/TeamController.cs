using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;
using TeamResourceTool.Models.Chart;
using TeamResourceTool.ViewModels;

namespace TeamResourceTool.Controllers
{
    public class TeamController : Controller
    {
        private ApplicationDbContext _context;
        public TeamController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Team
        public ActionResult Index(int id)
        {
            TempData["TeamID"] = id;
            var currentDate = DateTime.Now;
            var projects = _context.Project.Where(p => p.TeamId == id).ToList();

            var viewModel = new TeamDashboardViewModel
            {
                BuildProjects = projects.Where(p => p.GoLive > currentDate).ToList(),
                LiveProjects = projects.Where(p => currentDate >= p.GoLive && currentDate < p.EventStartDate).ToList(),
                InProgressProjects = projects.Where(p => currentDate >= p.EventStartDate && currentDate <= p.EventEndDate).ToList(),
                Resources = _context.Resource.Where(r => r.TeamId == id).OrderBy(r =>r.Role.Name).ToList()
            };

            viewModel.ProjectAssignedResources = GetProjectResources(viewModel.BuildProjects);

            ProjectsChart(projects);

            return View(viewModel);
        }

        private IEnumerable<Resource> GetProjectResources(IEnumerable<Project> projects)
        {
            var resources = new List<Resource>();
            foreach (var proj in projects)
            {
                resources.AddRange(projects.Where(p => p.Id == proj.Id).SelectMany(r => r.ProjectResource.Select(c => c.Resource)).ToList());
            }

            return resources;
        }

        private void ProjectsChart(IEnumerable<Project> projects)
        {
            List<TeamProjectsDataPoint> AllProjectsData = new List<TeamProjectsDataPoint>();
            AllProjectsData.Add(new TeamProjectsDataPoint(projects.Count(p => p.Status == "Active"), "Active"));
            AllProjectsData.Add(new TeamProjectsDataPoint(projects.Count(p => p.Status == "Closed"), "Closed"));
            AllProjectsData.Add(new TeamProjectsDataPoint(projects.Count(p => p.Status == "Cancelled"), "Cancelled"));
            AllProjectsData.Add(new TeamProjectsDataPoint(projects.Count(p => p.Status == "Pending / Hold"), "Pending / Hold"));

            ViewBag.AllProjectsDataPoints = JsonConvert.SerializeObject(AllProjectsData);
        }
    }
}