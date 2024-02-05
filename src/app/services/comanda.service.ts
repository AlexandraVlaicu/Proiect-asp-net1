import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comanda } from '../models/comanda.model';

@Injectable({
  providedIn: 'root',
})
export class ComandaService {
  private apiUrl = 'https://localhost:7182/api/comanda'; 

  constructor(private http: HttpClient) {}

  getOrders(): Observable<Comanda[]> {
    return this.http.get<Comanda[]>(this.apiUrl);
  }

  getOrderById(id: number): Observable<Comanda> {
    return this.http.get<Comanda>(`${this.apiUrl}/${id}`);
  }
}
