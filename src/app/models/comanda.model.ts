import { Client } from "./client.model";
import { DetaliuComanda } from "./detaliucomanda.model";
import { Livrare } from "./livrare.model";
import { Produs } from "./produs.model";

export interface Comanda {
    comandaID: number;
    clientID: number;
    dataPlasare: Date;
    status: string;
    produse: Produs[]; 
    detaliiComanda: DetaliuComanda[];
    livrare: Livrare; 
    client: Client; 
  }
  