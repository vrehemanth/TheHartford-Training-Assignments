import { Component, signal } from '@angular/core';
import { Calculator } from '../components/calculator/calculator';
import { Message } from '../components/message/message';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [Calculator, Message, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-3');
}
