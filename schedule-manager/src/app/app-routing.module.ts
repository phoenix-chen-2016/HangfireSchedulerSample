import { PagesModule } from './pages/pages.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';

const routes: Routes = [
	{ path: 'index', component: IndexComponent },
	{ path: '', component: IndexComponent }
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes),
		PagesModule
	],
	exports: [RouterModule]
})
export class AppRoutingModule { }
