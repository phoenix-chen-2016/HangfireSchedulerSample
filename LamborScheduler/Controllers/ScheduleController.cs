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

		public ScheduleController(IRecurringJobManager recurringJobManager)
		{
			m_RecurringJobManager = recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
		}
		[HttpPut]
		public Task CreateScheduleAsync(ScheduleInfoViewModel info)
		{
			m_RecurringJobManager.AddOrUpdateDbJob(info.Database, info.PercedureName, info.Cron);

			return Task.CompletedTask;
		}
	}
}
