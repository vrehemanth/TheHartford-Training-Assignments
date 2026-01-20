import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Calculator{
  add(a:number, b:number):number {
    return a + b;
  }
 
  subtract(a:number, b:number):number {
    return a - b;
  }

  multiply(a:number, b:number):number {
    return a * b;
  }

  divide(a:number, b:number):number {
    return b !== 0 ? a / b : 0;
  }

  mod(a:number, b:number):number {
    return b !== 0 ? a % b : 0;
  }
}
