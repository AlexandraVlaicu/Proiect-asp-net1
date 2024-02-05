import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produs } from '../models/produs.model';

@Injectable({
  providedIn: 'root',
})
export class ProdusService {
  private apiUrl = 'https://localhost:7182/api/produs'; 
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Produs[]> {
    return this.http.get<Produs[]>(this.apiUrl);
  }

  getProductById(id: number): Observable<Produs> {
    return this.http.get<Produs>(`${this.apiUrl}/${id}`);
  }
}
