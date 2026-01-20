import { Component,Input,Output,EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  imports: [CommonModule],
  templateUrl: './products.html',
  styleUrls: ['./products.css'],
})
export class Products {
  products=["Mobile","Laptop","TV","Speaker","Headphone"];
  tv=this.products[2];


  @Input() title!: string;          // string input
  @Input() product: string[] = []; // array input
  @Input() isEditable = false;



  @Output() productSelected = new EventEmitter<string>();

  selectProduct(product: string) {
    this.productSelected.emit(product); // 🔥 send data to parent
  }
}