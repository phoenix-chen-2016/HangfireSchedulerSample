using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Lambor.Schedule
{
	class DbConnectionFactory
	{
		private ConnectionOptions m_Options;

		public DbConnectionFactory(IOptions<ConnectionOptions> connectionOptionsAccessor)
		{
			m_Options = connectionOptionsAccessor.Value;
		}

		public IDbConnection GetDbConnection(string database)
		{
			var connectionString = string.Format(m_Options.ConnectionStringTemplate, database);

			return new SqlConnection(connectionString);
		}
	}
}
