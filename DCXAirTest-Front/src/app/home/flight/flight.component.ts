import { Component, OnInit } from '@angular/core';
import { City } from '../../interfaces/City';
import { Journey } from '../../interfaces/Journey';
import { Coin } from '../../interfaces/Coin';
import { Flight } from '../../interfaces/Flight';
import { FlghtService } from 'src/app/services/flight.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
  
  selectedOri: any = "";
  selectedDes: any = "";
  selectedCurrency: any = "";
  selectedTrip: any = "";
  enabledButton: boolean = false;

  constructor(private fService: FlghtService) {}

  allJourneysBack: Journey[] = [];

  ngOnInit(): void { }

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
    if (!this.selectedTrip || !this.selectedOri || !this.selectedCurrency || !this.selectedDes)
    {
      alert("Por favor, completa todos los campos antes de buscar vuelos.");
      console.log(this.selectedTrip)
      return;
    }
    else
    {
      if (this.selectedTrip === "oneway"){
        this.fService.getOneWayFlights(this.selectedOri,this.selectedDes,this.selectedCurrency).subscribe(data => {
                    this.allJourneysBack = data.data;
                    console.log(this.allJourneysBack);
                  });
      }
      if (this.selectedTrip === "roundtrip"){
        this.fService.getOneWayFlights(this.selectedOri,this.selectedDes,this.selectedCurrency).subscribe(data => {
          this.allJourneysBack = data as Journey[]
          console.log(this.allJourneysBack);
        });
      }
      else{
        this.allJourneysBack = [];
      }
    }
  }

}
