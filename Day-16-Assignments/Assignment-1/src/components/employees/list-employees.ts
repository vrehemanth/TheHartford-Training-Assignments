import { Component, OnInit } from '@angular/core';
import { Employee } from '../../app/models/employee.model';
import { DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-list-employees',
  imports: [DatePipe,CommonModule],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})

export class ListEmployees implements OnInit {
 employees: Employee[] = [
  {
    id: 1,
    name: 'Mark',
    gender: 'Male',
    contactPreference: 'Email',
    email: 'mark@pragimtech.com',
    dateOfBirth: new Date('10/25/1988'),
    department: 'IT',
    isActive: true,
    photoPath: 'assets/John.png'
  },
  {
    id: 2,
    name: 'Mary',
    gender: 'Female',
    contactPreference: 'Phone',
    phoneNumber: 2345978640,
    dateOfBirth: new Date('11/20/1979'),
    department: 'HR',
    isActive: true,
    photoPath: 'assets/Mary.png'
  },
  {
    id: 3,
    name: 'John',
    gender: 'Male',
    contactPreference: 'Phone',
    phoneNumber: 5432154321,
    dateOfBirth: new Date('3/25/1976'),
    department: 'IT',
    isActive: false,
    photoPath: 'assets/Mark.png'
  },
  ];
    ngOnInit() {
    }
  }  
