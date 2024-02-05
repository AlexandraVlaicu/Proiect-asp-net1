import { Produs } from "./produs.model";

export interface Categorie {
    categorieID: number;
    nume: string;
    produse?: Produs[]; 
  }
  