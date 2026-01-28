import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  imports: [FormsModule,RouterLink,RouterOutlet],
  templateUrl: './layout.html',
  styleUrl: './layout.css',
})
export class Layout {
  protected router=inject(Router)
  logOff() {
    localStorage.removeItem('loginUser');
    this.router.navigateByUrl('login');
  } 
  loggedUserData: any;
  constructor() {
    const loggedData = localStorage.getItem("loginUser");
      if (loggedData != null) {
      this.loggedUserData = loggedData;
    }
  }
}
