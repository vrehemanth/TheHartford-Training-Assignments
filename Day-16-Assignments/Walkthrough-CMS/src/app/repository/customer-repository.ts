import { Injectable } from '@angular/core';
import { Customer } from '../interface/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerRepository {
  private customers: Customer[] = [
    { id: 1, name: 'Ravi Kumar', email: 'ravi@gmail.com',phone: '9876543210', city: 'Delhi' },
    { id: 2, name: 'Anita Sharma', email:'anita@gmail.com', phone: '9876501234', city: 'Mumbai' },
    { id: 3, name: 'Suresh Patel', email:'suresh@gmail.com', phone: '9988776655', city: 'Ahmedabad' }
  ];
  getCustomers(): Customer[] {
    return this.customers;
  } 
}
