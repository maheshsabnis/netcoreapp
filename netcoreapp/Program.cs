using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace netcoreapp
{
    public class Program
    {
        /// <summary>
        /// Self-Hosting for the ASP.NET Core app
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IWebHostBuilder --> Manages Http Endpoints for Current Web App
        /// by creating Hosting Env. for the  application e.g.
        /// Manage--> Dependencies, Db Connections, Security, Routing, Middlewares
        /// and any other custom settings for the application using Startup class
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
