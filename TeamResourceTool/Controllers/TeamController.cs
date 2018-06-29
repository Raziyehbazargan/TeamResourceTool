using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamResourceTool.Models;

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
            return View();
        }
    }
}