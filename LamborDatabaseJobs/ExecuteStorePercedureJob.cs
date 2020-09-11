using Dapper;
using Hangfire.Server;
using System;
using System.Threading.Tasks;

namespace Lambor.Schedule
{
	class ExecuteStorePercedureJob : IPercedureExecutor
	{
		private readonly DbConnectionFactory m_DbConnectionFactory;

		public ExecuteStorePercedureJob(DbConnectionFactory dbConnectionFactory)
		{
			m_DbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
		}

		public async Task PerformAsync(string description, PerformContext context, PercedureInfo info)
		{
			using (var cn = m_DbConnectionFactory.GetDbConnection(info.Database))
			{
				await cn.ExecuteAsync(
					info.PercedureName,
					commandType: System.Data.CommandType.StoredProcedure).ConfigureAwait(false);
			}
		}
	}
}
