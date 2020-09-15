using System.Text.Json.Serialization;

namespace LamborScheduler.ViewModels
{
	public class ScheduleInfoViewModel
	{
		[JsonPropertyName("db")]
		public int Database { get; set; }

		[JsonPropertyName("sp")]
		public string PercedureName { get; set; }

		[JsonPropertyName("cron")]
		public string Cron { get; set; }
	}
}
