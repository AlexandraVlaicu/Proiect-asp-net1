import { Comanda } from "./comanda.model";
import { Produs } from "./produs.model";

export interface DetaliuComanda {
    detaliuComandaID: number;
    comandaID: number;
    produsID: number;
    cantitate: number;
    pretUnitar: number;
    comanda: Comanda; 
    produs: Produs; 
  }
  