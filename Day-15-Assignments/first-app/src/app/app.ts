import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Customers } from '../components/customers/customers';
import { Products } from '../components/products/products';

import { Header } from '../components/asmt-1/header/header';
import { Footer } from '../components/asmt-1/footer/footer';
import { Navbar } from '../components/asmt-1/navbar/navbar';
import { Description } from '../components/asmt-1/description/description';
import { WelcomeBanner } from '../components/asmt-1/welcome-banner/welcome-banner';
import { InsuranceProfiles } from '../components/asmt-1/insurance-profiles/insurance-profiles';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Customers, Products, Header, Footer, Navbar, Description, WelcomeBanner, InsuranceProfiles],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
//   showSecretMessage() {
//     alert('Mouse is over the section!');
//   }
//   productTitle = 'Available Products';

//   productList = ['Mobile', 'Laptop', 'TV'];

//   canEdit = true;

//   selectedProduct = '';

//   onProductSelected(product: string) {
//     this.selectedProduct = product;
//   }
}


// templateUrl: './app.html',
  // template: `
  //   <h1>Edit Content Example</h1>

  //   <div
  //     class="box"
  //     [contentEditable]="isEditable"
  //     (input)="onEdit($event)"
  //   >
  //     {{ content }}
  //   </div>

  //   <p><strong>Saved Content:</strong>  {{ content }}</p>

  //   <button (click)="enableEdit()">Edit</button>
  //   <button (click)="saveEdit()">Save</button>
  // `,


// isEditable = false;
  // content = 'Click Edit to modify this text';

  // enableEdit() {
  //   this.isEditable = true;
  // }

  // saveEdit() {
  //   this.isEditable = false;
  //   alert('Content saved!');
  // }

  // onEdit(event: Event) {
  //   const target = event.target as HTMLElement;
  //   this.content = target.innerText;  