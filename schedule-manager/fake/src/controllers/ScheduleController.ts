import { $log, BodyParams, Controller, Put } from "@tsed/common";

@Controller("/schedule")
export class ScheduleController {
	@Put("/")
	put(@BodyParams() body: any): void {
		$log.info("data recived", body);
	}
}
