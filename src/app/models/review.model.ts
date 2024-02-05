import { Client } from "./client.model";
import { Produs } from "./produs.model";

export interface Review {
    reviewID: number;
    clientID: number;
    comentariu: string;
    rating: number;
    dataReview: Date;
    produsID: number;
    client: Client;
    produs: Produs; 
  }
  