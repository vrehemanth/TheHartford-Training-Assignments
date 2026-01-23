import { HttpClient } from '@angular/common/http';
import { Injectable,inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TodoService{

  protected http=inject(HttpClient);
  API='http://localhost:3000/user';

  //Get All Users
  getTodos() {
    return this.http.get<any[]>(this.API);
  }

  //Get User by ID
  getTodoById(id: number) {
    return this.http.get<any>(`${this.API}/${id}`);
  }
  
  //Add User
  addUser(user: any) {
    return this.http.post(this.API, user);
  }

  //Update User
  updateUser(id: number, user: any) {
    return this.http.put(`${this.API}/${id}`, user);
  }

  //Delete User
  deleteUser(id: number) {
    return this.http.delete(`${this.API}/${id}`);
  }
}

