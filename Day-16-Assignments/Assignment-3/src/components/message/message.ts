import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Message as MessageService } from '../../app/services/message';

@Component({
  selector: 'app-message',
  imports: [FormsModule,CommonModule],
  templateUrl: './message.html',
  styleUrl: './message.css',
})
export class Message {
  message = '';
  messages: string[] = [];

  constructor(private msgService: MessageService) {
    this.messages = this.msgService.getData();
  }

  addMessage() {
    if (this.message.trim()) {
      this.msgService.addData(this.message);
      this.message = '';
    }
  }
}
