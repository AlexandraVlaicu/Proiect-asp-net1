import { Component, OnInit } from '@angular/core';
import { ProdusService } from '../services/produs.service';
import { Produs } from '../models/produs.model';

@Component({
  selector: 'app-product-list',
  template: `
    <h2>Product List</h2>
    <ul>
      <li *ngFor="let product of products">{{ product.name }}</li>
    </ul>
  `,
})
export class ListaProduseComponent implements OnInit {
  products: Produs[] = [];

  constructor(private produsService: ProdusService) {}

  ngOnInit() {
    this.produsService.getProducts().subscribe((data) => {
      this.products = data;
    });
  }
}
