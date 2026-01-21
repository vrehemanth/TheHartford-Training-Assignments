import { Component, signal } from '@angular/core';
import { CustomerList } from '../Components/customer-list/customer-list';

@Component({
  selector: 'app-root',
  imports: [CustomerList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Walkthrough-CMS');
}
