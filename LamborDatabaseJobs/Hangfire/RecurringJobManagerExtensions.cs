using Lambor.Schedule;

namespace Hangfire
{
	public static class RecurringJobManagerExtensions
	{
		public static void AddOrUpdateDbJob(
			this IRecurringJobManager recurringJobManager,
			string database,
			string percedureName,
			string cronExpression)
		{
			var percedureInfo = new PercedureInfo
			{
				Database = database,
				PercedureName = percedureName
			};

			recurringJobManager.AddOrUpdate(
				percedureName,
				(IPercedureExecutor executor) => executor.PerformAsync(percedureName, default, percedureInfo),
				cronExpression);
		}
	}
}
