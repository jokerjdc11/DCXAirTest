import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
  })
  export class FlightService  {

  constructor(private http: HttpClient) {}
  
  readonly apiUrl = 'https://localhost:7221/';

  getOneWayFlights(origin: string, destination: string, currency: string): Observable<any> {
    const params = new HttpParams()
      .set('origin', origin)
      .set('destination', destination)
      .set('currency', currency);
    return this.http.get(`${this.apiUrl}/Flights/oneWay`, { params });
  }
}