import { Component } from '@angular/core';
import { KebabCasePipe } from '../pipes/kebab-case-pipe';
import { ReversePipePipe } from '../pipes/reverse-pipe-pipe';

@Component({
  selector: 'app-pipes-demo',
  imports: [KebabCasePipe,ReversePipePipe],
  templateUrl: './pipes-demo.html',
  styleUrl: './pipes-demo.css',
})
export class PipesDemo {
  title ='Pipes Demo Component';
}
