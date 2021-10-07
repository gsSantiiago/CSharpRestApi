using CSharpRestApi.Models;
using System;
using MongoDB.Driver;
using MongoDB.Bson;
using CSharpRestApi.Classes;
using System.Linq;
using System.Collections.Generic;

namespace CSharpRestApi.Services
{
    public class VideoService
    {
        public static List<Video> GetAll(DB context, Server server)
        {
            try
            {
                return server.Videos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Video Get(DB context, Server server, Guid videoId)
        {
            try
            {
                return server.Videos.Where(v => v.Id == videoId).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Add(DB context, Guid serverId, Video video)
        {
            try
            {
                video.Id = Guid.NewGuid();

                UpdateDefinition<Server> update = Builders<Server>.Update.Push(s => s.Videos, video);

                context.Servers.FindOneAndUpdate(s => s.Id == serverId, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Update()
        {
            //var filter = Builders<Server>.Filter.Where(u => u.Videos.Any(c => c.Description == contactID));
            //var update = Builders<Server>.Update.PullFilter(u => u.Videos, c => c.Description == contactID);

            //context.Servers.UpdateOne(filter, update);
        }

        public static void Delete(DB context, Guid serverId, Guid videoId)
        {
            try
            {
                UpdateDefinition<Server> delete = Builders<Server>.Update.PullFilter(u => u.Videos, c => c.Id == videoId);

                context.Servers.UpdateOne(s => s.Id == serverId, delete);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
