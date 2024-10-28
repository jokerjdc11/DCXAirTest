import { Component, OnInit } from '@angular/core';
import { FlightService } from '../../services/fligth.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
  
  constructor(private fService: FlightService) {}

  ngOnInit(): void {
    
  }

  selectedOrigin: any = "";
  selectedDestination: any = "";
  selectedCurrency: any = "";
  selectedTrip: any = "";
  enabledButton: boolean = false;

  allJourneys: Journey[] = [];
  allJourneysBack: Journey[] = [];

  allCurrency:Coin[] = [{
    Name: "USD",
    Description: "Dolar"
  },{
    Name: "COP",
    Description: "Peso Colombiano"
  },
  {
    Name: "MXN",
    Description: "Pesos Mexicanos"
  }];

  onChange() {

  }

  addClick() {
    console.log("Form Submitted")

    if (!this.selectedTrip || !this.selectedOrigin || !this.selectedCurrency || !this.selectedDestination)
    {
        alert("There are missed data")
    }
    else
    {
      // this.fService.getOneWayFlights(this.selectedOrigin,this.selectedDestination,this.selectedCurrency).subscribe(data => {
      //             this.allJourneys = data as Journey[]
      //             console.log(this.allJourneys);
      //           });
      if (this.selectedTrip === "Round Trip"){
        // this.fService.getOneWayFlights(this.selectedDestination,this.selectedOrigin,this.selectedCurrency).subscribe(data => {
        //   this.allJourneysBack = data as Journey[]
        //   console.log(this.allJourneysBack);
        // });
        console.log("round");
      }
      else{
        console.log("Hola");
        this.allJourneysBack = [];
      }
    }
  }
}

interface Coin {
  Name: string;
  Description: string;
}

interface Journey {
  origin: string;
  destination: string;
  coin: string;
  price: number;
  flights: Flight [];
}

interface Flight {
  coin: string;
  destination: string;
  id: number;
  nameTransport: string;
  origin: string;
  price: number;
  priceCoin: number;
  transportId: number;
}