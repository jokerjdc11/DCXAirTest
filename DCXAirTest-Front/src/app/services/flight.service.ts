import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlghtService {
  private apiUrl = 'https://localhost:7221';

  constructor(private http: HttpClient) { }
  
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
