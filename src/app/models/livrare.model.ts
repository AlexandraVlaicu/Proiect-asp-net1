import { Comanda } from "./comanda.model";

export interface Livrare {
    livrareID: number;
    comandaID: number;
    dataLivrare: Date;
    stare: string;
    comanda: Comanda; 
  }
  