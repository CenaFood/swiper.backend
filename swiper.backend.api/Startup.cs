﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ch.cena.swiper.backend.service.Service;
using Microsoft.EntityFrameworkCore;
using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.services.Contracts;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using ch.cena.swiper.backend.service.Contracts.Configuration;
using ch.cena.swiper.backend.service.Contracts;
using ImageMigrator;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System;
using ch.cena.swiper.backend.data.Models;

namespace ch.cena.swiper.backend.api
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
            services.AddEntityFrameworkNpgsql().AddDbContext<SwiperContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));


            services.AddIdentity<User, ApplicationRole>()
                .AddEntityFrameworkStores<SwiperContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc();

            services.AddOptions();
            services.Configure<HostConfig>(Configuration.GetSection("Hosting"));
            services.Configure<StorageConfig>(Configuration.GetSection("Storage"));
            services.Configure<MigrationConfig>(Configuration.GetSection("Migration"));

            services.AddTransient<IAnnotationService, AnnotationService>();
            services.AddTransient<IChallengeService, ChallengeService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IImageService, ImageService>();

            services.AddTransient<UserService, UserService>();
            services.AddTransient<MigrateService, MigrateService>();
            services.AddTransient<SwiperMigrator, SwiperMigrator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            SwiperContext context, 
            IOptions<HostConfig> hostConfig, 
            IOptions<StorageConfig> storageConfig,
            IOptions<MigrationConfig> migrationConfig,
            SwiperMigrator migrator)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                storageConfig.Value.ImageFolder),
                RequestPath = new PathString(hostConfig.Value.ImageHostFolder)
            });

            app.UseAuthentication();            
            if (migrationConfig.Value.Migrate)
            {
                // Create DB on startup and do the migrations. Manual migrations are NOT needed anymore
                context.Database.Migrate();
                migrator.Migrate();
            }
        }
    }
}
