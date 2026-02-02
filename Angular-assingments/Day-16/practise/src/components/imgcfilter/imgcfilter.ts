import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-imgcfilter',
  imports: [FormsModule],
  templateUrl: './imgcfilter.html',
  styleUrl: './imgcfilter.css',
})
export class Imgcfilter {
  blur = 0;
  gray = 0;
  
}
