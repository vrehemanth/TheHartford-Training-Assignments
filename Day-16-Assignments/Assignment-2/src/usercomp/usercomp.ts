import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../interface/user';

@Component({
  selector: 'app-usercomp',
  imports: [FormsModule],
  templateUrl: './usercomp.html',
  styleUrl: './usercomp.css',
})
export class Usercomp {
  users: User[] = []; 
  user: User = {
    id: 0,
    name: '',
    email: ''
  };
  isEditMode = false;
  // CREATE & UPDATE
  saveUser() {
  if (this.isEditMode) {
    const index = this.users.findIndex(u => u.id === this.user.id);
    this.users[index] = { ...this.user };
    this.isEditMode = false;
  }else { 
    this.user.id = Date.now(); 
    this.users.push({ ...this.user });
  }
  this.resetForm();
  }
  // EDIT
  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }
  // DELETE
  deleteUser(id: number) {
    this.users = this.users.filter(u => u.id !== id);
  }
  resetForm(){
    this.user = { id: 0, name: '', email: '' };
  } 
}
