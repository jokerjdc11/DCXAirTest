import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
  })
  export class FlightService  {

  constructor(private http: HttpClient) {}
  
  private apiUrl = 'https://localhost:7221/';

  getOneWayFlights(origin: string, destination: string, currency: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/Flights/oneWay`, {
      params: { origin, destination, currency }
    });
  }

  getRoundTripFlights(origin: string, destination: string, currency: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/Flights/roundTrip`, {
      params: { origin, destination, currency }
    });
  }
}