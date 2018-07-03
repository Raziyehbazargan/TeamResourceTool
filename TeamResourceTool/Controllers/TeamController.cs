using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;
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
                InProgressProjects = projects.Where(p => currentDate >= p.EventStartDate && currentDate <= p.EventEndDate).ToList()
            };  

            return View(viewModel);
        }
    }
}