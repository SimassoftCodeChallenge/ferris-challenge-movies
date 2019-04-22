using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace Ferris.Challenge.Movies.WebApi
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen( c => {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Movies API",
                    Version = "v1",
                    Description = "A simple service to search movies info",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Luís Gabriel N. Simas",
                        Email = "gabrielsimas@gmail.com",
                        Url = "https://github.com/gabrielsimas"
                    }                    
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();            
        }
    }
}
