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
    public class ResourcesApiController : ApiController
    {
        private ApplicationDbContext _context;
        public ResourcesApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/resources
        public IHttpActionResult GetResources()
        {
            return Ok(_context.Resource.ToList().Select(Mapper.Map<Resource, ResourceDTO>));
        }

        // GET api/resources/1
        public IHttpActionResult GetResources(int id)
        {
            var resource = _context.Resource.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Resource, ResourceDTO>(resource));
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
            return Created(new Uri(Request.RequestUri + "/" + resource.Id), resourceDto);
        }


        // PUT api/resources/1
        [HttpPut]
        public IHttpActionResult UpdateResource(int id, ResourceDTO resourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resourceInDb = _context.Resource.SingleOrDefault(r => r.Id == id);
            if (resourceInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(resourceDto, resourceInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/resources/1
        [HttpDelete]
        public IHttpActionResult DeleteResource(int id)
        {
            var resourceInDb = _context.Resource.SingleOrDefault(p => p.Id == id);
            if (resourceInDb == null)
            {
                return NotFound();
            }

            _context.Resource.Remove(resourceInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
