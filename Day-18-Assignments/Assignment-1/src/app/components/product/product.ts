import { Component } from '@angular/core';
import { Rating } from '../rating/rating';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product',
  imports: [Rating, CommonModule, FormsModule],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class Product {
   products = [
    { id: 1, name: 'iPhone 17 Pro Max', rating: 0 },
    { id: 2, name: 'Samsung Galaxy S26 Ultra', rating: 0 },
    { id: 3, name: 'Google Pixel 10 Pro', rating: 0 },
    { id: 4, name: 'OnePlus 12', rating: 0 }
  ];

  updateRating(index: number, value: number) {
    this.products[index].rating = value;
  }
}
