using Lambor.Schedule;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddLamborHangfireDbJobs(
			this IServiceCollection services,
			Action<ConnectionOptions, IServiceProvider> configureOptions)
		{
			return services
				.AddOptions<ConnectionOptions>()
				.Configure(configureOptions)
				.Services
				.AddSingleton<DbConnectionFactory>()
				.AddTransient<IPercedureExecutor, ExecuteStorePercedureJob>();
		}
	}
}
