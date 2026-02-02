import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatuspipePipe } from '../../pipes/statuspipe-pipe';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, StatuspipePipe],
  templateUrl: './orders.html',
})
export class OrdersComponent {
  orders = [
    { id: 1, name: 'Laptop' },
    { id: 2, name: 'Phone' },
    { id: 3, name: 'Headphones' },
    { id: 4, name: 'Keyboard' },
    { id: 5, name: 'Mouse' },
    { id: 99, name: 'Monitor' }
  ];
}
