using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bagdxk.Profile.Service.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bagdxk.Profile.Service.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IValuesService, ValuesService>();
            services.AddSingleton<ILayoutRepository>(new LayoutCosmosDbRepository(
                "https://bagdxk-profile-service-db.documents.azure.com:443/"
                , "h715qPKYFYfQ8631n7q8gam8q074wX4LJALZKbniN65bfofoaxFtQjjyHajJ1OMhhvybQsPuyYA4MExcWo3cdA=="));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
