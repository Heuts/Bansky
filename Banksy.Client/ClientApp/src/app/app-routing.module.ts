import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MutationOverviewComponent } from './components/mutation-overview/mutation-overview.component';
import { MutationDetailComponent } from './components/mutation-detail/mutation-detail.component';


const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
      {
        path: "mutation-overview",
        component: MutationOverviewComponent,
        pathMatch: "full"
      },
      {
        path: "mutation-detail/:mutationId",
        component: MutationDetailComponent,
        pathMatch: "full"
      }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
