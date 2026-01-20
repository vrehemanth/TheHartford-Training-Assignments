import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Message {
  private data: string[] = [];

  getData(): string[]{
    return this.data;
  }

  addData(message: string): void {
    this.data.push(message);
  }
}
