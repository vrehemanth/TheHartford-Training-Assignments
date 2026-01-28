import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Calci {
  add(n1:number,n2:number):number{
    return n1+n2;
  }
  sub(n1:number,n2:number):number{
    return n1-n2;
  }
  mul(n1:number,n2:number):number{
    return n1*n2;
  }
  div(n1:number,n2:number):number{
    return n1/n2;
  }
  mod(n1:number,n2:number):number{
    return n1%n2;
  }
}
