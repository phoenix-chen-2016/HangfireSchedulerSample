import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { FormsModule } from '@angular/forms';



@NgModule({
	declarations: [IndexComponent],
	imports: [
		CommonModule,
		FormsModule
	]
})
export class PagesModule { }
