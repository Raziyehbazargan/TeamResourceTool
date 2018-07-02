using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;

namespace TeamResourceTool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teams = GetTeams();
            List<DataPoint> buildProjects = new List<DataPoint>();
            List<DataPoint> liveProjects = new List<DataPoint>();
            List<DataPoint> pendingProjects = new List<DataPoint>();

            foreach (var team in teams)
            {
                var buildProjectsCount = team.Projects.Where(p => p.GoLive > DateTime.Now).Count(p => p.Status == "Active");
                var liveProjectsCount = team.Projects.Where(p => p.GoLive < DateTime.Now).Count(p => p.Status == "Active");
                var pendingProjectsCount = team.Projects.Count(p => p.Status.Contains("Hold"));
                buildProjects.Add(new DataPoint(buildProjectsCount, team.Name));
                liveProjects.Add(new DataPoint(liveProjectsCount, team.Name));
                pendingProjects.Add(new DataPoint(pendingProjectsCount, team.Name));
            }

            ViewBag.BuildDataPoints = JsonConvert.SerializeObject(buildProjects);
            ViewBag.LiveDataPoints = JsonConvert.SerializeObject(liveProjects);
            ViewBag.PendingDataPoints = JsonConvert.SerializeObject(pendingProjects);

            return View(teams);
        }

        // GET: Teams
        private IEnumerable<Team> GetTeams()
        {
            return _context.Team.ToList();
        }

        // GET: Team/ProjectList/id
        private IEnumerable<Project> GetProjects(int id)
        {
            return _context.Project.Where(t => t.TeamId == id).ToList();
        }
    }
}