import { Component, signal } from '@angular/core';
import { Usercomp } from '../usercomp/usercomp';

@Component({
  selector: 'app-root',
  imports: [Usercomp],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-2');
}
