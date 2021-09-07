using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RealGames.Contexts;
using RealGames.Repositories.BundleRepository;
using RealGames.Repositories.CategoryRepository;
using RealGames.Repositories.DeveloperRepository;
using RealGames.Repositories.GameBundleRepository;
using RealGames.Repositories.GameCategoryRepository;
using RealGames.Repositories.GameRepository;

namespace RealGames
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IBundleRepository, BundleRepository>();
            services.AddTransient<IGameBundleRepository, GameBundleRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IGameCategoryRepository, GameCategoryRepository>();
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
            app.UseMvc();


        }
    }
}