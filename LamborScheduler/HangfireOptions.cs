namespace LamborScheduler
{
	public class HangfireOptions
	{
		public bool UseMemory { get; set; } = true;

		public string RedisConnectionString { get; set; }

		public int RedisDbIndex { get; set; }
	}
}
