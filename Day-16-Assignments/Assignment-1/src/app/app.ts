import { Component, signal} from '@angular/core';
import {FormsModule} from '@angular/forms';
import { ListEmployees } from '../components/employees/list-employees';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [FormsModule,ListEmployees,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('second-app');
}