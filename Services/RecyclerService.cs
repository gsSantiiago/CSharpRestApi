using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CSharpRestApi.Classes;
using CSharpRestApi.Models;
using CSharpRestApi.ViewModels;
using MongoDB.Driver;

namespace CSharpRestApi.Services
{
    public class RecyclerService
    {
        public static void Process(DB context, int days)
        {
            try
            {
                FilterDefinition<Server> serverWithVideoFilter = Builders<Server>.Filter.ElemMatch(z => z.Videos, a => a.CreatedAt <= DateTime.Now.AddDays(days * -1));

                List<Server> serverWithVideo = context.Servers.Find(serverWithVideoFilter).ToList();

                serverWithVideo.ForEach(s =>
                {
                    s.Videos.ToList().ForEach(v =>
                    {
                        if (v.CreatedAt.ToUniversalTime() <= DateTime.Now.AddDays(days * -1).ToUniversalTime())
                        {
                            VideoService.Delete(context, s.Id, v.Id);
                        }
                    });
                });

                Thread.Sleep(5000); // force delay to test status route

                RecyclerTaskViewModel.RecyclerTask = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
