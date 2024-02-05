import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalii-produs',
  template: '<h2>Detalii produs pentru un id: {{ productId }}</h2>',
})
export class DetaliiProdusComponent {
  productId: string;

  constructor(private route: ActivatedRoute) {
    const id = this.route.snapshot.paramMap.get('id');
    this.productId = id !== null ? id : 'default-value'; 
  }
}