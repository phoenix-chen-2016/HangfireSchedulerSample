import { DatabaseInfo } from './database-info';
import { SchedulerService } from './../../services/scheduler.service';
import { ScheduleInfo } from './../../models/schedule-info';
import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2/dist/sweetalert2';

@Component({
	selector: 'app-index',
	templateUrl: './index.component.html',
	styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
	databases: DatabaseInfo[] = [
		{
			id: 0,
			displayName: '-- 請選擇 --'
		},
		{
			id: 1,
			displayName: 'Comm_CashFlow'
		},
		{
			id: 2,
			displayName: 'Comm_Code'
		},
		{
			id: 3,
			displayName: 'Comm_Logs'
		},
		{
			id: 4,
			displayName: 'Lambor_Code'
		},
		{
			id: 5,
			displayName: 'Lambor_Game'
		},
		{
			id: 6,
			displayName: 'Lambor_Main'
		},
		{
			id: 7,
			displayName: 'Lambor_ReportData'
		},
		{
			id: 8,
			displayName: 'Lambor_Users'
		}
	];

	scheduleInfo: ScheduleInfo = {
		database: 0,
		percedureName: '',
		cron: ''
	};

	constructor(
		private scheduler: SchedulerService
	) { }

	ngOnInit(): void {
	}

	async createSchedule(): Promise<void> {
		try {
			await this.scheduler
				.addSchedule(
					this.scheduleInfo.database,
					this.scheduleInfo.percedureName,
					this.scheduleInfo.cron)
				.toPromise();

			Swal.fire('Success', 'You submitted succesfully!');
		}
		catch (ex) {
			console.log(ex);
			Swal.fire('fail', ex.message, 'error');
		}
	}
}
