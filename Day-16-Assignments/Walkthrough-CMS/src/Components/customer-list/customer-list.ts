import { Component } from '@angular/core';
import { CustomerRepository } from '../../app/repository/customer-repository';
import { Customer } from '../../app/interface/customer';

@Component({
  selector: 'app-customer-list',
  imports: [],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.css',
})
export class CustomerList {
  customers: Customer[] = [];
 constructor(private customerRepo: CustomerRepository) { }
 ngOnInit(): void {
 this.customers = this.customerRepo.getCustomers();
 }
}
