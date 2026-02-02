import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrdersComponent } from "./components/orders/orders";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, OrdersComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('pipedemo');
}
