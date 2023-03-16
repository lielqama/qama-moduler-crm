using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ModulerCrm.Helpers;
using QamaCoreShared.Helpers;
using QamaCoreShared.Middleware;
using QamaCoreShared.Middleware.Authorization;
using QamaCoreShared.Helpers.DataContext;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using modulercrm.Services;
using QamaCoreShared.Services.StringService;
using QamaCoreShared.Services;
using QamaCoreShared.Services.LoginService;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.IO;
using Hangfire;
using Hangfire.SqlServer;
using static modulercrm.Services.IQamaModulerService;


namespace WebApi
{
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// add services to the DI container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "modulercrm API", Version = "v1" });

                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = @"Send ApiKey in query param",
                    Name = "apikey",
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "apikey"
                });
                 var key = new OpenApiSecurityScheme()           
       {                   
           Reference = new OpenApiReference                 
           {                
               Type = ReferenceType.SecurityScheme,       
               Id = "ApiKey"                    },          
           In = ParameterLocation.Query                };  
                var requirement = new OpenApiSecurityRequirement        
                {                      
                { key, new List<string>() }};   
                c.AddSecurityRequirement(requirement);
              

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
     

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<List<PriorityConfig>>(Configuration.GetSection("PrioritySettings"));
            services.Configure<modulerSettings>(Configuration.GetSection("modulerSettings"));

            // configure DI for application services
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddSingleton<ILoggerService, LoggerService>();
            services.TryAddSingleton<IMailService, MailService>();

            services.AddScoped<IStringSerivce, HeStringSerivce>();
            services.AddScoped<IQamaService, QamaService>();

            services.AddScoped<IQamaCoreSharedContext, DataContext>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILoginService, NoLoginService>();
            services.AddScoped<IPriorityService, PriorityService>();
            services.AddScoped<IPriorityFactory, PriorityFactory>();


           
            services.AddScoped<IQamaModulerService, QamaModulerService>();
            

        }

        /// <summary>
        /// configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="context"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            // migrate database changes on startup (includes initial db creation)
            context.Database.Migrate();

            // generated swagger json and swagger ui middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (env.IsDevelopment())
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModulerCrm API V1");
                else
                    c.SwaggerEndpoint("https://api.qama.co.il/ModulerCrm/swagger/v1/swagger.json", "ModulerCrm API V1");
                c.RoutePrefix = "";
            });
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            //// custom jwt auth middleware
            app.UseMiddleware<ApiParamTokenMiddleware>();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            // Use Https
            app.UseHttpsRedirection();


        }
    }
}
