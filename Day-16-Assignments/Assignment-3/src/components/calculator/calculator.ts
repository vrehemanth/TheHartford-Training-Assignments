import { Component } from '@angular/core';
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

  constructor(private calcService: CalculatorService) {}

  add() {
    this.result = this.calcService.add(this.a, this.b);
    this.operation = '+';
    this.showResult = true;
  }

  subtract() {
    this.result = this.calcService.subtract(this.a, this.b);
    this.operation = '-';
    this.showResult = true;
  }

  multiply() {
    this.result = this.calcService.multiply(this.a, this.b);
    this.operation = '*';
    this.showResult = true;
  }

  divide() {
    this.result = this.calcService.divide(this.a, this.b);
    this.operation = '/'; 
    this.showResult = true;
  }

  mod() {
    this.result = this.calcService.mod(this.a, this.b);
    this.operation = '%'; 
    this.showResult = true;
  }
}
