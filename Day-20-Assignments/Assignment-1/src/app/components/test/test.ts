import { Component,inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test',
  imports: [],
  templateUrl: './test.html',
  styleUrl: './test.css',
})
export class Test {

  protected router=inject(Router);
  gotoHome() {
    this.router.navigate(['/home']);
  }
}
