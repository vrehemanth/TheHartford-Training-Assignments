import { HttpClient } from '@angular/common/http';
import { Injectable,inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TodoService {

  protected http=inject(HttpClient);
  API='http://localhost:3000/user';

  //Get All Users
  getTodos() {
    return this.http.get<any[]>(this.API);
  }

  //Get User by ID
  getTodoById(id: string) {
    return this.http.get<any>(`${this.API}/${id}`);
  }
  
  //Add User
  addUser(user: any) {
    return this.http.post(this.API, user);
  }

  //Update User
  updateUser(id: string, user: any) {
    return this.http.put(`${this.API}/${id}`, user);
  }

  //Delete User
  deleteUser(id: string) {
    return this.http.delete(`${this.API}/${id}`);
  }
}

