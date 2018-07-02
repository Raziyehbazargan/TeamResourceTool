using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;
using TeamResourceTool.ViewModels;

namespace TeamResourceTool.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;
        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Project
        public ActionResult Index()
        {
            //var teamID = TempData["TeamID"];
            var projects = _context.Project.ToList();
            return View(projects);
        }

        [HttpGet]
        public ActionResult Details(byte teamID, int projectID)
        {
            TempData["ProjectID"] = projectID;
            TempData["TeamID"] = teamID;

            var viewModel = new ProjectDetails
            {
                Project = _context.Project.Where(p => p.Id == projectID).FirstOrDefault(),
                Resources = _context.Project.Where(p => p.Id == projectID).SelectMany(r => r.ProjectResource.Select(c => c.Resource)).ToList(),
                OnsiteResources = _context.Project.Where(p => p.Id == projectID).SelectMany(r => r.ProjectResource.Where(pr => pr.OnSite).Select(c => c.Resource)).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new ProjectCreateViewModel
            {
                Teams = _context.Team.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AssignResource(int id, int pId)
        {
            var viewModel = new AssignResource
            {
                Resources = _context.Resource.Where(r => r.TeamId == id).ToList(),
                Project = _context.Project.Where(p => p.Id == pId).FirstOrDefault()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AssignResource(ProjectResource details)
        {
            if (ModelState.IsValid)
            {
                _context.ProjectResource.Add(details);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Project project)
        {
            if(ModelState.IsValid)
            {
                _context.Project.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}