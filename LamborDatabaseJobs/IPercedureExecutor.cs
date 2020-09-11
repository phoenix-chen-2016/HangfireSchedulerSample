using Hangfire.Server;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Lambor.Schedule
{
	public interface IPercedureExecutor
	{
		[DisplayName("{0}")]
		Task PerformAsync(string description, PerformContext context, PercedureInfo info);
	}
}
