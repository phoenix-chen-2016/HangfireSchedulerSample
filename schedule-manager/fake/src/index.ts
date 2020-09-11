import { $log } from "@tsed/common";
import { PlatformExpress } from "@tsed/platform-express";
import { Server } from "./Server";

async function bootstrap(): Promise<void> {
	try {
		$log.debug("Start server...");
		const platform = await PlatformExpress.bootstrap(Server);

		await platform.listen();
		$log.debug("Server initialized");
	} catch (er) {
		$log.error(er);
	}
}

bootstrap();
