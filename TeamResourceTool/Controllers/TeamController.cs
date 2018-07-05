using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;
using TeamResourceTool.Models.Chart;
using TeamResourceTool.ViewModels;
using System.Data.Entity;

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
            var projects = _context.Project.Where(p => p.TeamId == id).OrderBy(p => p.Id).ThenBy(p => p.Name).ToList();

            var viewModel = new TeamDashboardViewModel
            {
                BuildProjects = GetProjectResources(projects),
                LiveProjects = projects.Where(p => currentDate >= p.GoLive && currentDate < p.EventStartDate).ToList(),
                InProgressProjects = projects.Where(p => currentDate >= p.EventStartDate && currentDate <= p.EventEndDate).ToList(),
                Resources = _context.Resource.Where(r => r.TeamId == id).OrderBy(r =>r.Role.Name).ToList()
            };

            ProjectsChart(projects);

            return View(viewModel);
        }


        // GET: Resources
        public ActionResult GetResources(int id)
        {
            var resources = _context.Resource.Where(r => r.TeamId == id).Include(r => r.Role).ToList();
            return View("Resources",resources);
        }

        private IEnumerable<Project> GetProjectResources(IEnumerable<Project> projects)
        {
            var buildProjects = projects.Where(p => p.GoLive > DateTime.Now).ToList();

            var resourcesList = buildProjects.ToLookup(p => p.Id);
            foreach (var item in buildProjects)
            {
                item.Resources = resourcesList[item.Id].SelectMany(r => r.ProjectResource.Select(c => c.Resource)).ToList();
            }
            return buildProjects;
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