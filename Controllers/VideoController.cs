using System;
using System.Collections.Generic;
using CSharpRestApi.Classes;
using CSharpRestApi.Models;
using CSharpRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly DB Context = new();

        [Route("~/api/servers/{serverId}/videos")]
        [HttpGet]
        public ActionResult<List<Video>> GetAll(Guid serverId)
        {
            Server server = ServerService.Get(Context, serverId);

            if (server is null)
                return NotFound();

            return VideoService.GetAll(Context, server);
        }

        [Route("~/api/servers/{serverId}/videos/{videoId}")]
        [HttpGet]
        public ActionResult<Video> Get(Guid serverId, Guid videoId)
        {
            Server server = ServerService.Get(Context, serverId);

            if (server is null)
                return NotFound();

            Video video = VideoService.Get(Context, server, videoId);

            if (video == null)
                return NotFound();

            return video;
        }

        [Route("~/api/servers/{serverId}/videos")]
        [HttpPost]
        public IActionResult Create(Guid serverId, Video video)
        {
            Server server = ServerService.Get(Context, serverId);

            if (server == null)
                return NotFound();

            VideoService.Add(Context, serverId, video);
            return CreatedAtAction(nameof(Create), new { id = video.Id }, video);
        }

        [Route("~/api/servers/{serverId}/videos/{videoId}")]
        [HttpDelete]
        public IActionResult Delete(Guid serverId, Guid videoId)
        {
            Server server = ServerService.Get(Context, serverId);

            if (server is null)
                return NotFound();

            Video video = VideoService.Get(Context, server, videoId);

            if (video is null)
                return NotFound();

            VideoService.Delete(Context, serverId, videoId);

            return NoContent();
        }
    }
}
