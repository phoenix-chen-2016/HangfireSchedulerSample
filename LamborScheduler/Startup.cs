using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LamborScheduler
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services
				.AddLamborHangfireDbJobs((options, sp) => { })
				.AddHangfire(config =>
				{
					config
						.UseSimpleAssemblyNameTypeSerializer()
						.UseRecommendedSerializerSettings()
						.UseConsole()
						.UseMemoryStorage();
				})
				.AddHangfireServer();

			services.Configure<ForwardedHeadersOptions>(options =>
			{
				options.ForwardLimit = 3;
				options.ForwardedHeaders = ForwardedHeaders.All;
				options.KnownNetworks.Clear();
				options.KnownProxies.Clear();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseForwardedHeaders();
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHangfireDashboard(new DashboardOptions
				{
					Authorization = new IDashboardAuthorizationFilter[0]
				});
				endpoints.MapControllers();
			});
		}
	}
}
