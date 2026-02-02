import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from "../components/navbar/navbar";
import { Home } from "../components/home/home";
import { Welcome } from "../components/welcome/welcome";
import { InsuranceProfiles } from "../components/insurance-profiles/insurance-profiles";
import { Footer } from "../components/footer/footer";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, Home, Welcome, InsuranceProfiles, Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('hartford');
}
