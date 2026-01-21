import { Component,inject } from '@angular/core';
import { Calculator as CalculatorService } from '../../app/services/calculator';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-calculator',
  imports: [FormsModule],
  templateUrl: './calculator.html',
  styleUrl: './calculator.css',
})
export class Calculator {
  a = 0;
  b = 0;
  result = 0;
  operation = '';
  showResult = false;

  protected calci=inject(CalculatorService);

  add() {
    this.result = this.calci.add(this.a, this.b);
    this.operation = '+';
    this.showResult = true;
  }

  subtract() {
    this.result = this.calci.subtract(this.a, this.b);
    this.operation = '-';
    this.showResult = true;
  }

  multiply() {
    this.result = this.calci.multiply(this.a, this.b);
    this.operation = '*';
    this.showResult = true;
  }

  divide() {
    this.result = this.calci.divide(this.a, this.b);
    this.operation = '/'; 
    this.showResult = true;
  }

  mod() {
    this.result = this.calci.mod(this.a, this.b);
    this.operation = '%'; 
    this.showResult = true;
  }
}
