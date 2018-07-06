using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamResourceTool.Dtos;
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
        public IEnumerable<ProjectDTO> GetProjects()
        {
            return _context.Project.ToList().Select(Mapper.Map<Project, ProjectDTO>);
        }

        // GET api/projects/1
        public ProjectDTO GetProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Id == id);

            if(project == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Project, ProjectDTO>(project);
        }

        // POST api/projects
        [HttpPost]
        public ProjectDTO CreateProject(ProjectDTO projectDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var project = Mapper.Map<ProjectDTO, Project>(projectDto);
            _context.Project.Add(project);
            _context.SaveChanges();

            projectDto.Id = project.Id;
            return projectDto;
        }

        // PUT api/projects/1
        [HttpPut]
        public void UpdateProject(int id, ProjectDTO projectDto)
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
            Mapper.Map(projectDto, projectInDb);
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
