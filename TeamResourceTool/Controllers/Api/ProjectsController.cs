using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamResourceTool.Models;

namespace TeamResourceTool.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/projects
        public IEnumerable<Project> GetProjects()
        {
            return _context.Project.ToList();
        }

        // GET api/projects/1
        public Project GetProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Id == id);

            if(project == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return project;
        }

        // POST api/projects
        [HttpPost]
        public Project CreateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Project.Add(project);
            _context.SaveChanges();

            return project;
        }

        // PUT api/projects/1
        [HttpPut]
        public void UpdateProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var projectInDb = _context.Project.SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.SaveChanges();
        }

        // DELETE api/projects/1
        [HttpDelete]
        public void DeleteProject(int id)
        {
            var projectInDb = _context.Project.SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Project.Remove(projectInDb);
            _context.SaveChanges();
        }
    }
}
