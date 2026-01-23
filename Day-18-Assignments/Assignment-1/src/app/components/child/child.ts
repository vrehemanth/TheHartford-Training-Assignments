import { Component,Input,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  imports: [],
  templateUrl: './child.html',
  styleUrl: './child.css',
})
export class Child {
  // @Input() messageFromParent: string = '';

  @Output() dataChanged = new EventEmitter<string>();

  sendToParent(data: string ) {
    this.dataChanged.emit(data);
  }
}
