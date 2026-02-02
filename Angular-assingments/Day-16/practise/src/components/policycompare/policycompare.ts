import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-policycompare',
  imports: [FormsModule],
  templateUrl: './policycompare.html',
  styleUrl: './policycompare.css',
})
export class Policycompare {
  cashless = false;
  maternity = false;
  
}
