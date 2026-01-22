import { Component, signal } from '@angular/core';
import { TodoListComponents } from '../components/todo-list-components/todo-list-components';

@Component({
  selector: 'app-root',
  imports: [TodoListComponents],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-1');
}
