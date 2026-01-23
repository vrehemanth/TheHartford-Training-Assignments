import { Component,inject,OnInit } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { TodoService } from '../../app/services/todo-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-list-components',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list-components.html',
  styleUrl: './todo-list-components.css',
})
export class TodoListComponents implements OnInit {
  protected todoService = inject(TodoService);
  protected cdr = inject(ChangeDetectorRef);
  users: any[] = [];
  
  userForm = {
    id: null,
    name: '',
    email: '',
    age: '',
    city: '',
  };

  ngOnInit() {
    this.loadUsers();
  }

  //Fetch Users
  loadUsers() {
    this.todoService.getTodos().subscribe(data => {
      this.users = data;
      this.cdr.detectChanges();
    });
  }
  saveUser() {
    //Update User
    if(this.userForm.id){
      this.todoService.updateUser(this.userForm.id, this.userForm)
        .subscribe(() => this.loadUsers());
    }else{
      //Add User
      const newUser = { ...this.userForm};
      this.todoService.addUser(newUser)
        .subscribe(() => this.loadUsers());
    }
    this.resetForm();
  }

  editUser(user: any) {
    this.userForm = { ...user };
  }

  //Delete User
  deleteUser(id: number) {
    this.todoService.deleteUser(id)
      .subscribe(() => this.loadUsers());
  }

  //Reset Form
  resetForm() {
    this.userForm = {
      id: null,
      name: '',
      email: '',
      age: '',
      city: '',
    };
  };
}
