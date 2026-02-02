import { Injectable } from '@angular/core';
import { Employee } from '../model/employeesmodel';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  private employees: Employee[] = [
    {
      id: 1,
      name: 'Mark Anderson',
      gender: 'Male',
      department: 'IT',
      email: 'mark@company.com',
      isActive: true,
      photoPath: 'mark.jpg'
    },
    {
      id: 2,
      name: 'Mary Johnson',
      gender: 'Female',
      department: 'HR',
      phoneNumber: 9876543210,
      isActive: true,
      photoPath: 'mary.jpg'
    },
    {
      id: 3,
      name: 'John Williams',
      gender: 'Male',
      department: 'Finance',
      email: 'john@company.com',
      isActive: false,
      photoPath: 'john.jpeg'
    },
    {
      id: 4,
      name: 'Sara Smith',
      gender: 'Female',
      department: 'Admin',
      phoneNumber: 9123456789,
      isActive: true,
      photoPath: 'sara.jpg'
    }
  ];

  // READ
  getEmployees(): Employee[] {
    return [...this.employees];
  }

  // CREATE
  addEmployee(emp: Employee): void {
    this.employees.push(emp);
  }

  // UPDATE
  updateEmployee(emp: Employee): void {
    const index = this.employees.findIndex(e => e.id === emp.id);
    if (index !== -1) {
      this.employees[index] = emp;
    }
  }

  // DELETE
  deleteEmployee(id: number): void {
    this.employees = this.employees.filter(e => e.id !== id);
  }
}
