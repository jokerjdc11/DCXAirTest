import { Routes } from '@angular/router';
import { FlightComponent } from './home/flight/flight.component';

export const routes: Routes = [
    { path: '', component:  FlightComponent},
    { path: 'flights', component: FlightComponent },
    { path: 'home/flights', component: FlightComponent },
    { path: 'home', component: FlightComponent }
];
