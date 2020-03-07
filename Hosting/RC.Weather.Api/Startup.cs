using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Common.IoC;
using RC.Weather.Presentation.IoC;

namespace RC.Weather.Api
{
	public class Startup
	{
		private const string WeatherCorsPolicy = "WeatherCorsPolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var allowedHosts = this.Configuration.GetSection("AllowedHosts").Get<string[]>();

			services.AddSingleton(this.Configuration);
			services.AddPresentationServices(this.Configuration);
			services.AddCommonServices(this.Configuration);
			services.AddCors(o => o.AddPolicy(WeatherCorsPolicy, builder =>
			{
				builder
					.WithOrigins(allowedHosts)
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

			app.UseCors(WeatherCorsPolicy);
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
