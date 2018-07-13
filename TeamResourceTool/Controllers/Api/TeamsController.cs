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
    public class TeamsController : ApiController
    {
        private ApplicationDbContext _context;
        public TeamsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/teams
        public IHttpActionResult GetTeams()
        {
            return Ok(_context.Team.ToList().Select(Mapper.Map<Team, TeamDTO>));
        }

        // GET api/team/resources
        public IHttpActionResult GetResources(int id)
        {
            return Ok(_context.Resource.Where(r => r.TeamId == id).ToList().Select(Mapper.Map<Resource, ResourceDTO>));
        }


        // POST api/resources
        [HttpPost]
        public IHttpActionResult CreateResource(ResourceDTO resourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resource = Mapper.Map<ResourceDTO, Resource>(resourceDto);
            _context.Resource.Add(resource);
            _context.SaveChanges();

            resourceDto.Id = resource.Id;
            return Created(new Uri(Request.RequestUri + "/" + resource.Id), resourceDto); // by REST convention we should return uri of new data
        }


        // PUT api/Teams/1
        [HttpPut]
        public IHttpActionResult UpdateTeam(int id, TeamDTO teamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var teamInDb = _context.Team.SingleOrDefault(t => t.Id == id);
            if (teamInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(teamDto, teamInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/Teams/1
        [HttpDelete]
        public IHttpActionResult DeleteTeam(int id)
        {
            var teamInDb = _context.Team.SingleOrDefault(t => t.Id == id);
            if (teamInDb == null)
            {
                return NotFound();
            }

            _context.Team.Remove(teamInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
