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
    public class ProjectsApiController : ApiController
    {
        private ApplicationDbContext _context;
        public ProjectsApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/projects
        public IHttpActionResult GetProjects()
        {
            return Ok(_context.Project.ToList().Select(Mapper.Map<Project, ProjectDTO>));
        }

        // GET api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Id == id);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Project, ProjectDTO>(project));
        }

        // POST api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDTO projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var project = Mapper.Map<ProjectDTO, Project>(projectDto);
            _context.Project.Add(project);
            _context.SaveChanges();

            projectDto.Id = project.Id;
            return Created(new Uri(Request.RequestUri + "/" + project.Id), projectDto);
        }

        // PUT api/projects/1
        [HttpPut]
        public IHttpActionResult UpdateProject(int id, ProjectDTO projectDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var projectInDb = _context.Project.SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(projectDto, projectInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/projects/1
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            var projectInDb = _context.Project.SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
            {
                return NotFound();
            }

            _context.Project.Remove(projectInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
