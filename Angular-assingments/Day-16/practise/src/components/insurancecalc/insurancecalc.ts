import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-insurancecalc',
  imports: [FormsModule],
  templateUrl: './insurancecalc.html',
  styleUrl: './insurancecalc.css',
})
export class Insurancecalc {
  age = 25;
sumInsured = 500000;

get premium() {
  let base = this.sumInsured / 1000;
  let ageFactor = this.age > 40 ? 1.5 : 1;

  return Math.round(base * ageFactor);
}


}
