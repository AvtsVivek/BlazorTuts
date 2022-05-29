using System.Collections.Generic;
using System.Diagnostics;
using Ardalis.ListStartupServices;
using Autofac;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
//using OData.Core;
//using OData.Core.ProjectAggregate;
//using OData.Infrastructure;

using Autofac.Extensions.DependencyInjection;
using BlazorApiCall.Core;
using BlazorApiCall.Infrastructure;
using BlazorApiCall.Infrastructure.Data;

using Serilog;
// using BlazorApiCall.Core.Configuration;

namespace BlazorApiCall.Web;

public class Startup
{
  private readonly IWebHostEnvironment _env;

  public Startup(IConfiguration config, IWebHostEnvironment env)
  {
    Configuration = config;
    _env = env;
  }
  public IConfiguration Configuration { get; }

  public virtual void ConfigureServices(IServiceCollection services)
  {
    // services.AddCors();
    //services.AddCors(options =>
    //{
    //  options.AddPolicy("PolicyName", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    //});

    //services.AddCors(options =>
    //{
    //  options.AddPolicy("Name",
    //  builder =>
    //  {
    //    builder.WithOrigins("*").AllowAnyHeader().WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS");
    //  });
    //});

    services.AddControllers()
    //  .AddOData(options =>
    //options
    //.AddRouteComponents("OData", GetEntityDataModel())
    //.Select().Filter().OrderBy().SetMaxTop(5)
    //.Expand())
      ;

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    var connectionString = Configuration.GetConnectionString("SqliteConnection");  //Configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext(connectionString);

    // services.Configure<AzureDNSServiceSettings>(Configuration.GetSection(nameof(AzureDNSServiceSettings)));

    services.AddControllersWithViews()
      //.AddNewtonsoftJson()
      ;
    services.AddRazorPages();

    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
      c.EnableAnnotations();
    });

    // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
    services.Configure<ServiceConfig>(config =>
    {
      config.Services = new List<ServiceDescriptor>(services);

      // optional - default path to view services is /listallservices - recommended to choose your own path
      config.Path = "/listservices";
    });

  }

  public virtual void ConfigureContainer(ContainerBuilder builder)
  {
    builder.RegisterModule(new DefaultCoreModule());
    builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName == "Development"));
  }

  public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {

    if (_env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseShowAllServicesMiddleware();
    }
    else
    {
      app.UseExceptionHandler("/Home/Error");
      app.UseHsts();
    }
    app.UseRouting();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCookiePolicy();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapDefaultControllerRoute();
      endpoints.MapRazorPages();
    });

    //app.UseCors(x => x
    //  .AllowAnyMethod()
    //  .AllowAnyHeader()
    //  .SetIsOriginAllowed(origin => true) // allow any origin  
    //  .AllowCredentials());               // allow credentials 
  }

  //private IEdmModel GetEntityDataModel()
  //{
  //  var builder = new ODataConventionModelBuilder();

  //  builder.Namespace = "Projects";

  //  builder.ContainerName = "ProjectsContainer";

  //  builder.EntitySet<Project>("Projects");

  //  return builder.GetEdmModel();
  //}

}

