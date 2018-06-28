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
            return View(teams);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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