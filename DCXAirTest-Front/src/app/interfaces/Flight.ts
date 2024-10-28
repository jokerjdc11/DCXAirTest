import { Transport } from "./Transport";
export interface Flight {
    id: number;
    origin: string;
    destination: string;
    price: number;
    priceCoin: number;
    transport: Transport [];
}

