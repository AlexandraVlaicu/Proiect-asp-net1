import { Comanda } from "./comanda.model";
import { Review } from "./review.model";

export interface Client {
    clientID: number;
    nume: string;
    adresa: string;
    comenzi?: Comanda[]; 
    reviews?: Review[]; 
  }
  