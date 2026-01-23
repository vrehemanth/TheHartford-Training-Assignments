import { Component, signal} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CurrencyPipe, DatePipe,TitleCasePipe,UpperCasePipe,CommonModule } from '@angular/common';
import { PipesDemo } from './components/pipes-demo/pipes-demo';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PipesDemo, CurrencyPipe, DatePipe, TitleCasePipe, UpperCasePipe, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  protected readonly title = signal('Assignment-1');
  //Build-in Pipes
  amount = 123.45;
  company = 'acme corporation';
  firstName = 'john';
  lastName = 'doe';
  isAdmin = true;
  purchasedOn = '2026-01-23';
}
