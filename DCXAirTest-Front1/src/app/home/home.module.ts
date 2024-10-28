import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FlightComponent } from './flight/flight.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    FlightComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    HomeRoutingModule,
  ],
  exports:[
    FlightComponent
  ],
})
export class HomeModule { }
