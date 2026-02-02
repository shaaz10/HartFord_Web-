import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListEmployees } from "../components/employee/employee";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListEmployees],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Employees2');
}
