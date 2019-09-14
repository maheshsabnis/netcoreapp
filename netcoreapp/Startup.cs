using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using netcoreapp.Models;
using netcoreapp.Services;
using Newtonsoft.Json.Serialization;
using netcoreapp.Middlewares;

namespace netcoreapp
{
    public class Startup
    {
        /// <summary>
        /// IConfiguration is injected by WebHost class. This is used to read the
        /// appsettings.json file
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        //Use this method to add Dependency services to the container.
        // DependencyInjectionExtensions naespace for managing all dependencies
        public void ConfigureServices(IServiceCollection services)
        {
            // inject the DbContext into the DI Container
            // AddSingleTon(), AddScope() --> Session / Stateful, 
            // AddTransient() --> PerCall // Stateless 
            // Use Sql Server for DbContext and use the Connection String
            services.AddDbContext<CoreFisContext>(options=> {
                options.UseSqlServer(Configuration.GetConnectionString
                        ("ApplicationConnection")); 
            });

            // define cors extensions
            services.AddCors(options => {
                options.AddPolicy("corspolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            // register all repositories in DI

            services.AddScoped<IRepository<Category,int>,CategoryRepository>();
            services.AddScoped<IRepository<Product, int>, ProductRepository>();

            services.AddMvc() // provide the JSON serialization 
                // for data in as-it-is format for entitied
                 .AddJsonOptions(options => options.SerializerSettings.ContractResolver
              = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        // IApplicationBuilder --> Interface that act as acontract for adding
        // custom middlewares(?) in the current Http Pipeline
        // IHostingEnvironment --> Contract betwen Host env and Current Web App
        // Used by WebHost class
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // define CORS Policy
            app.UseCors("corspolicy");
            // the custom exception Middlewaare
            app.UseErrorMiddleware();
            app.UseMvc();
        }
    }
}
