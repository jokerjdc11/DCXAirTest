import { Flight } from "./Flight";
export interface Journey {
  origin: string;
  destination: string;
  coin: string;
  price: number;
  flights: Flight [];
}
