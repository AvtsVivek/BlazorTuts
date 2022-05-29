using Ardalis.ListStartupServices;
using Autofac;
using Microsoft.OpenApi.Models;

namespace BlazorApiCall.WebTempWorking
{
  public class Startup
  {
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      _env = env;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddControllersWithViews();

      services.AddRazorPages();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ch20Ex01", Version = "v1" });
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
      // builder.RegisterModule(new DefaultCoreModule());
      // builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName == "Development"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      app.UseCors(cors => cors
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true)
          .AllowCredentials()
      );

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
    }
  }
}
