using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CSharpRestApi.Models;
using CSharpRestApi.Services;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CSharpRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly DB Context = new();

        public ServerController()
        {
        }

        [Route("~/api/servers")]
        [HttpGet]
        public ActionResult<List<Server>> GetAll()
        {
            return ServerService.GetAll(Context);
        }

        [Route("~/api/servers/{id}")]
        [HttpGet]
        public ActionResult<Server> Get(Guid id)
        {
            var server = ServerService.Get(Context, id);

            if (server == null)
                return NotFound();

            return server;
        }

        [Route("~/api/server")]
        [HttpPost]
        public IActionResult Create(Server server)
        {            
            ServerService.Add(Context, server);
            return CreatedAtAction(nameof(Create), new { id = server.Id }, server);
        }

        [Route("~/api/servers/{id}")]
        [HttpPut]
        public ActionResult<Server> Update(Guid id, Server server)
        {
            Server existingServer = ServerService.Get(Context, id);

            if (existingServer is null)
                return NotFound();

            ServerService.Update(Context, id, server);

            return ServerService.Get(Context, id);
        }

        [Route("~/api/servers/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var server = ServerService.Get(Context, id);

            if (server is null)
                return NotFound();

            ServerService.Delete(Context, id);

            return NoContent();
        }
    }
}