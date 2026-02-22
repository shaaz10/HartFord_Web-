import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../../services/customers';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customers.html'
})
export class CustomersComponent implements OnInit {

  customers: any[] = [];
  isLoading = true;
  error: string | null = null;

  // Create form model
  newCustomer = {
    name: '',
    email: '',
    city: '',
    totalPurchases: 0,
    isActive: true
  };

  // Editing model
  editingCustomer: any = null;

  constructor(
    private customerService: CustomerService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  // =========================
  // LOAD CUSTOMERS
  // =========================
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

  // =========================
  // CREATE
  // =========================
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

  // =========================
  // EDIT (populate form)
  // =========================
  editCustomer(customer: any): void {
    this.editingCustomer = { ...customer };
  }

  // =========================
  // UPDATE
  // =========================
  updateCustomer(): void {
    if (!this.editingCustomer) return;

    this.customerService
      .updateCustomer(this.editingCustomer.id, this.editingCustomer)
      .subscribe({
        next: () => {
          this.editingCustomer = null;
          this.loadCustomers();
        }
      });
  }

  // =========================
  // DELETE
  // =========================
  deleteCustomer(id: string): void {
    this.customerService.deleteCustomer(id).subscribe({
      next: () => {
        this.loadCustomers();
      }
    });
  }
}
