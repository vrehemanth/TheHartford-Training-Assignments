import { Component } from '@angular/core';
import { RouterLink,RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-first',
  imports: [RouterLink, RouterOutlet], 
  templateUrl: './first.html',
  styleUrl: './first.css',
})
export class First {

}
