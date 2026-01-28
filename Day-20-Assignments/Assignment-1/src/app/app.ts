import { Component, signal } from '@angular/core';
import { RouterOutlet,Router,RouterLink,RouterLinkActive } from '@angular/router';
import { inject } from '@angular/core';
import { Test } from './components/test/test';

@Component({
  selector: 'app-root',
  imports: [RouterLink, RouterOutlet, RouterLinkActive,Test],
  templateUrl: './app.html',
  styleUrl: './app.css'
})  
export class App {
  protected readonly title = signal('Assignment-1');
  protected router=inject(Router);    
}
