import { Categorie } from "./categorie.model";
import { Comanda } from "./comanda.model";
import { DetaliuComanda } from "./detaliucomanda.model";
import { Review } from "./review.model";

export interface Produs {
    produsID: number;
    nume: string;
    pret: number;
    stoc: number;
    descriere: string;
    categorieId: number;
    detaliiComanda?: DetaliuComanda[];
    categorii?: Categorie; 
    comenzi?: Comanda[]; 
    reviews?: Review[]; 
  }
  