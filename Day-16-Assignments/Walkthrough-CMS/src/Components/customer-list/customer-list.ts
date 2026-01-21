import { Component,inject } from '@angular/core';
import { CustomerRepository } from '../../app/repository/customer-repository';
import { Customer } from '../../app/interface/customer';

@Component({
  selector: 'app-customer-list',
  imports: [],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.css',
})
export class CustomerList {
  protected customerRepo = inject(CustomerRepository);
  customers: Customer[] = this.getCustomers();
  getCustomers(): Customer[] {
    return this.customerRepo.getCustomers();
  }
}
