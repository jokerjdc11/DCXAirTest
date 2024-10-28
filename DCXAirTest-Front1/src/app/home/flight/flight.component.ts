import { Component, OnInit } from '@angular/core';
import { FlightService } from '../../services/fligth.service';
import { City } from '../../interfaces/City';
import { Journey } from '../../interfaces/Journey';
import { Coin } from '../../interfaces/Coin';
import { Flight } from '../../interfaces/Flight';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
  
  selectedOri: any = "";
  selectedDes: any = "";
  selectedValue: any = "";
  selectedTrip: any = "";
  enabledButton: boolean = false;

  allJourneys: Journey[] = [];
  allJourneysBack: Journey[] = [];

  constructor(private fService: FlightService) {}

  ngOnInit(): void {
    
  }

  allCurrency: Coin[] = [
    { Name: "USD", Description: "Dolar"},
    { Name: "COP", Description: "Peso Colombiano"},
    { Name: "MXN", Description: "Pesos Mexicanos"}
  ];

  allCities: City[] = [
    {
    Name: "MZL",
    Description: "Manizales",
    },
    {
    Name: "PEI",
    Description: "Pereira",
    },
    {
    Name: "JFK",
    Description: "Jhon F.Kenedy",
    },
    {
    Name: "BCN",
    Description: "Barcelona",
    },
    {
    Name: "MAD",
    Description: "Madrid",
    }
  ]

  onChange() {

  }

  addClick() {
    console.log(this.selectedTrip)

    if (!this.selectedTrip || !this.selectedOri || !this.selectedValue || !this.selectedDes)
    {
        alert("There are missed data")
    }
    else
    {
      this.fService.getOneWayFlights(this.selectedOri,this.selectedDes,this.selectedValue).subscribe(data => {
                  this.allJourneys = data as Journey[]
                  console.log(this.allJourneys);
                });
      if (this.selectedTrip === "Round Trip"){
        this.fService.getOneWayFlights(this.selectedOri,this.selectedDes,this.selectedValue).subscribe(data => {
          this.allJourneysBack = data as Journey[]
          console.log(this.allJourneysBack);
        });
        console.log("round");
      }
      else{
        console.log("Hola");
        this.allJourneysBack = [];
      }
    }
  }
}
