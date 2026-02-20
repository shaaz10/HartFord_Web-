import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrl = 'http://localhost:5115/api/Customer';

  constructor(private http: HttpClient) {}

  // GET ALL
  getCustomers(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  // CREATE
  createCustomer(customer: any): Observable<any> {
    return this.http.post(this.apiUrl, customer);
  }

  // UPDATE (id should be string)
  updateCustomer(id: string, customer: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, customer);
  }

  // DELETE (id should be string)
  deleteCustomer(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
