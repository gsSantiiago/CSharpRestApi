using CSharpRestApi.Models;
using System;
using MongoDB.Driver;
using CSharpRestApi.Classes;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CSharpRestApi.ViewModels;

namespace CSharpRestApi.Services
{
    public class VideoService
    {
        private static readonly string VideosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "server-videos");

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

        public static string GetBinary(DB context, Server server, Guid videoId)
        {
            try
            {
                Video video = server.Videos.Where(v => v.Id == videoId).FirstOrDefault();

                string videoName = video.Id + ".mp4";
                string videoPath = Path.Combine(VideosPath, videoName);

                return Utils.FileToBase64String(videoPath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Video Add(DB context, Guid serverId, VideoViewModel videoViewModel)
        {
            try
            {
                Video video = new() { Id = Guid.NewGuid(), Description = videoViewModel.Description };

                if (!Directory.Exists(VideosPath))
                {
                    Directory.CreateDirectory(VideosPath);
                }

                string videoName = video.Id + ".mp4";
                string videoPath = Path.Combine(VideosPath, videoName);

                Utils.Base64StringToFile(videoPath, videoViewModel.Base64);

                FileInfo fileInfo = new(videoPath);
                video.SizeInBytes = fileInfo.Length;

                UpdateDefinition<Server> update = Builders<Server>.Update.Push(s => s.Videos, video);

                context.Servers.FindOneAndUpdate(s => s.Id == serverId, update);

                return video;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Delete(DB context, Guid serverId, Guid videoId)
        {
            try
            {
                UpdateDefinition<Server> delete = Builders<Server>.Update.PullFilter(u => u.Videos, c => c.Id == videoId);

                context.Servers.UpdateOne(s => s.Id == serverId, delete);

                string videoName = videoId + ".mp4";
                string videoPath = Path.Combine(VideosPath, videoName);

                if(File.Exists(videoPath))
                {
                    File.Delete(videoPath);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
