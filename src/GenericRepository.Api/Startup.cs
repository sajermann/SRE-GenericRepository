using GenericRepository.Application;
using GenericRepository.Application.Interfaces;
using GenericRepository.Data;
using GenericRepository.Data.Context;
using GenericRepository.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace GenericRepository.Api
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

      services.AddControllers()
      .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
          Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      var serverVersion = new MySqlServerVersion(new Version(5, 7, 26));
      services.AddDbContext<GRContext>(
          context => context.UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
      );
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "GenericRepository.Api", Version = "v1" });
      });

      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IRoleService, RoleService>();
      services.AddScoped<IApplicationService, ApplicationService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericRepository.Api v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
