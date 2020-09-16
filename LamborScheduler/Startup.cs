using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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
				.AddOptions<HangfireOptions>()
				.Configure<IConfiguration>((options, config) =>
				{
					config.GetSection("Hangfire").Bind(options);
				})
				.Services
				.AddLamborHangfireDbJobs((options, sp) =>
				{
					var config = sp.GetRequiredService<IConfiguration>();

					config.GetSection("LamborConnection").Bind(options);
				})
				.AddHangfire((sp, config) =>
				{
					var options = sp.GetRequiredService<IOptions<HangfireOptions>>().Value;

					config
						.UseSimpleAssemblyNameTypeSerializer()
						.UseRecommendedSerializerSettings()
						.UseConsole();

					if (options.UseMemory)
						config.UseMemoryStorage();
					else
					{
						config.UseRedisStorage(
							options.RedisConnectionString,
							new Hangfire.Redis.RedisStorageOptions
							{
								Db = options.RedisDbIndex
							});
					}
				})
				.AddHangfireServer();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

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
