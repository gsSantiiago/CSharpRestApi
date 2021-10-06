using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CSharpRestApi.Models;
using CSharpRestApi.Services;

namespace CSharpRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        public ServerController()
        {
        }

        [Route("~/api/servers")]
        [HttpGet]
        public ActionResult<List<Server>> GetAll() =>
        ServerService.GetAll();

        [Route("~/api/servers/{id}")]
        [HttpGet]
        public ActionResult<Server> Get(Guid id)
        {
            var server = ServerService.Get(id);

            if(server == null)
                return NotFound();

            return server;
        }

        [Route("~/api/server")]
        [HttpPost]
        public IActionResult Create(Server server)
        {            
            ServerService.Add(server);
            return CreatedAtAction(nameof(Create), new { id = server.Id }, server);
        }

        [Route("~/api/servers/{id}")]
        [HttpPut]
        public IActionResult Update(Guid id, Server server)
        {
            if (!id.Equals(server.Id))
                return BadRequest();

            var existingServer = ServerService.Get(id);

            if(existingServer is null)
                return NotFound();

            ServerService.Update(server);           

            return NoContent();
        }

        [Route("~/api/servers/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var server = ServerService.Get(id);

            if (server is null)
                return NotFound();

            ServerService.Delete(id);

            return NoContent();
        }
    }
}