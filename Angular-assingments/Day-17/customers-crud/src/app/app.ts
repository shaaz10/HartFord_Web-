import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomersComponent } from "./components/customers/customers";

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet, CustomersComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('customers');
}
