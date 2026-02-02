import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { Employee } from '../../app/model/employeesmodel';
import { EmployeesService } from '../../app/services/employeeservice';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee.html'
})
export class ListEmployees {

  private service = inject(EmployeesService);

  employees: Employee[] = [];

  employeeForm: Employee = this.emptyEmployee();
  editMode = false;

  constructor() {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employees = this.service.getEmployees();
  }

  save(): void {
    if (this.editMode) {
      this.service.updateEmployee(this.employeeForm);
    } else {
      this.employeeForm.id = Date.now();
      this.service.addEmployee(this.employeeForm);
    }
    this.reset();
    this.loadEmployees();
  }

  edit(emp: Employee): void {
    this.employeeForm = { ...emp };
    this.editMode = true;
  }

  delete(id: number): void {
    this.service.deleteEmployee(id);
    this.loadEmployees();
  }

  reset(): void {
    this.employeeForm = this.emptyEmployee();
    this.editMode = false;
  }

  private emptyEmployee(): Employee {
    return {
      id: 0,
      name: '',
      gender: 'Male',
      department: '',
      isActive: true,
      photoPath: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf1fiSQO7JfDw0uv1Ae_Ye-Bo9nhGNg27dwg&s'
    };
  }
}
