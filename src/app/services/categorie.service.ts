import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Categorie } from '../models/categorie.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'https://localhost:7182/api/categorie'; 

  constructor(private http: HttpClient) {}

  getCategorie(): Observable<Categorie[]> {
    return this.http.get<Categorie[]>(this.apiUrl);
  }

  getCategorieById(id: number): Observable<Categorie> {
    return this.http.get<Categorie>(`${this.apiUrl}/${id}`);
  }
}
