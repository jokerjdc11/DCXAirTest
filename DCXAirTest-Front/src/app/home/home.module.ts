import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { FlightComponent } from './flight/flight.component';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FlightComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HomeRoutingModule,
    HttpClientModule
  ],
  exports:[
    FlightComponent
  ],
  providers: [
    provideHttpClient(
      withFetch()
    ) 
  ],
})
export class HomeModule { }
