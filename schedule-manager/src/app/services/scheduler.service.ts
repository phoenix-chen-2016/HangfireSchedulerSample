import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class SchedulerService {

	constructor(
		private http: HttpClient
	) { }

	addSchedule(db: number, sp: string, cron: string): Observable<any> {
		return this.http.put(
			'/api/schedule',
			{
				db,
				sp,
				cron
			});
	}
}
