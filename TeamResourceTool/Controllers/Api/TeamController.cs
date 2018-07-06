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
    public class TeamController : ApiController
    {
        private ApplicationDbContext _context;
        public TeamController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/team/resources
        public IHttpActionResult GetTeamResources(int id)
        {
            return Ok(_context.Resource.Where(r => r.TeamId == id).ToList().Select(Mapper.Map<Resource, ResourceDTO>));
        }
    }
}
