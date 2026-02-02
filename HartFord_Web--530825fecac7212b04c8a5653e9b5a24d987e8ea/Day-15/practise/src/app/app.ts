import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TwoWayBinding } from '../components/two-way-binding/two-way-binding';
import { Slider } from "../components/slider/slider";
import { Imgchange } from "../components/imgchange/imgchange";
import { Imgcfilter } from "../components/imgcfilter/imgcfilter";
import { Insurancecalc } from "../components/insurancecalc/insurancecalc";
import { Policycompare } from "../components/policycompare/policycompare";



@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TwoWayBinding, Slider, Imgchange, Imgcfilter, Insurancecalc, Policycompare],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('practise');
}
