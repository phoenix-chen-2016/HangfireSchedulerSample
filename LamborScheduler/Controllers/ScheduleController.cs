using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using LamborScheduler.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LamborScheduler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly IRecurringJobManager m_RecurringJobManager;
		private readonly Dictionary<int, string> m_DatabaseMapping;

		public ScheduleController(IRecurringJobManager recurringJobManager)
		{
			m_RecurringJobManager = recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
			m_DatabaseMapping = new Dictionary<int, string>
			{
				[1] = "Comm_CashFlow",
				[2] = "Comm_Code",
				[3] = "Comm_Logs",
				[4] = "Lambor_Code",
				[5] = "Lambor_Game",
				[6] = "Lambor_Main",
				[7] = "Lambor_ReportData",
				[8] = "Lambor_Users"
			};
		}
		[HttpPut]
		public Task CreateScheduleAsync(ScheduleInfoViewModel info)
		{
			m_RecurringJobManager.AddOrUpdateDbJob(m_DatabaseMapping[info.Database], info.PercedureName, info.Cron);

			return Task.CompletedTask;
		}
	}
}
