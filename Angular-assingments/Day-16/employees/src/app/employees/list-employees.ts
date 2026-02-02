import { Component } from '@angular/core';
import { Employee } from '../models/employees.models';
import { DatePipe } from '@angular/common';
import { NgFor } from '@angular/common';
import { CommonModule } from '@angular/common';

                 // ✅ angular (correct)


@Component({
  selector: 'app-list-employees',
  standalone:true,
  imports: [CommonModule,NgFor,DatePipe],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})
export class ListEmployees {
  
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
        photoPath: 'mark.jpg'
      },
      {
        id: 2,
        name: 'Mary',
        gender: 'Female',
        contactPreference: 'Phone',
        phoneNumber: 2345976848,
        dateOfBirth: new Date('11/20/1979'),
        department: 'HR',
        isActive: true,
        photoPath: 'mary.jpg'
      },
      {
        id: 3,
        name: 'John',
        gender: 'Male',
        contactPreference: 'Phone',
        phoneNumber: 5432978640,
        dateOfBirth: new Date('04/18/1992'),
        department: 'Finance',
        isActive: false,
        photoPath: 'john.jpeg'
      },
      {
        id: 4,
        name: 'Sara',
        gender: 'Female',
        contactPreference: 'Email',
        email: 'sara@pragimtech.com',
        dateOfBirth: new Date('07/15/1985'),
        department: 'Admin',
        isActive: true,
        photoPath: 'sara.jpg'
      }
    ];
  
  
  
}
