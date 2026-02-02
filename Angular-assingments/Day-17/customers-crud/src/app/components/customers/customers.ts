import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../../services/customers';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './customers.html'
})
export class CustomersComponent implements OnInit {

  customers: any[] = [];
  isLoading = true;
  error: string | null = null;

  // form model
  newCustomer = {
    name: '',
    email: '',
    city: '',
    totalPurchases: 0,
    isActive: true
  };

  editingCustomer: any = null;

  constructor(
    private customerService: CustomerService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe({
      next: (res: any) => {
        this.customers = Array.isArray(res) ? res : res.customers;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
       error: () => {
        this.error = 'Failed to load customers';
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  // CREATE
  addCustomer(): void {
    this.customerService.createCustomer(this.newCustomer).subscribe({
      next: () => {
        this.newCustomer = {
          name: '',
          email: '',
          city: '',
          totalPurchases: 0,
          isActive: true
        };
        this.loadCustomers();
      }
    });
  }

  // EDIT (fill form)
  editCustomer(customer: any): void {
    this.editingCustomer = { ...customer };
  }

  // UPDATE
  updateCustomer(): void {
    this.customerService
      .updateCustomer(this.editingCustomer.id, this.editingCustomer)
      .subscribe({
        next: () => {
          this.editingCustomer = null;
          this.loadCustomers();
        }
      });
  }

  // DELETE
  deleteCustomer(id: number): void {
    this.customerService.deleteCustomer(id).subscribe({
      next: () => {
        this.loadCustomers();
      }
    });
  }
}
