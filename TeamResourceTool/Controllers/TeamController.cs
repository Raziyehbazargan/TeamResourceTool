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
using System.Threading.Tasks;
using System.Globalization;

namespace TeamResourceTool.Controllers
{
    public class TeamController : Controller
    {
        private readonly DateTime currentDate = DateTime.Now;

        private ApplicationDbContext _context;
        public TeamController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private IEnumerable<Project> CloseProject(IEnumerable<Project> projects)
        {
            var closedProjects = new List<Project>();
            foreach (var item in projects)
            {
                if (item.EventEndDate < currentDate)
                {
                    item.Status = "Closed";
                    if(item.EventEndDate < currentDate.AddDays(-14))
                    {
                        closedProjects.Add(item);
                    }      
                }
            }
            return closedProjects;
        }
        // GET: Team
        public ActionResult Index(int id)
        {
            TempData["TeamID"] = id;
            var projects = _context.Project.Where(p => p.TeamId == id).OrderBy(p => p.Id).ThenBy(p => p.Name).ToList();            

            var viewModel = new TeamDashboardViewModel
            {
                BuildProjects = GetProjectResources(projects),
                LiveProjects = projects.Where(p => currentDate >= p.GoLive && currentDate < p.EventStartDate).ToList(),
                InProgressProjects = projects.Where(p => currentDate >= p.EventStartDate && currentDate <= p.EventEndDate).ToList(),
                ClosedProjects = CloseProject(projects),
                Resources = _context.Resource.Where(r => r.TeamId == id).OrderBy(r => r.Role.Name).ToList()
            };

            ProjectsChart(projects);
            ProjectsInYearChart(projects);
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
            var buildProjects = projects.Where(p => p.GoLive > currentDate).ToList();

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

        private void ProjectsInYearChart(IEnumerable<Project> projects)
        {
            List<DataPoint> AllProjectsData = new List<DataPoint>();
            int currectYear = DateTime.Now.Year;

            for (int i = 1; i <= 12; i++)
            {
                AllProjectsData.Add(new DataPoint(projects.Count(p => p.BuildStart.Value.Year == currectYear && p.BuildStart.Value.Month == i ), DateTimeFormatInfo.CurrentInfo.GetMonthName(i)));
            }

            ViewBag.AllProjectInYearDataPoints = JsonConvert.SerializeObject(AllProjectsData);
        }
    }
}