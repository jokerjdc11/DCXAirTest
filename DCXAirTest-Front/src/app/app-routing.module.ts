import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightComponent } from './home/flight/flight.component';

const routes: Routes = [
  { path: '', component:  FlightComponent},
  { path: 'flights', component: FlightComponent },
  { path: 'home/flights', component: FlightComponent },
  { path: 'home', component: FlightComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
