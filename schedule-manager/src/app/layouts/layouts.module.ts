import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { MenuComponent } from './menu/menu.component';
import { NavigateComponent } from './navigate/navigate.component';



@NgModule({
	declarations: [
		FooterComponent,
		MenuComponent,
		NavigateComponent
	],
	imports: [
		CommonModule
	],
	exports: [
		FooterComponent,
		MenuComponent,
		NavigateComponent
	]
})
export class LayoutsModule { }
