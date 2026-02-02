import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';


@Component({
  selector: 'app-slider',
  imports: [FormsModule],
  templateUrl: './slider.html',
  styleUrl: './slider.css',
})
export class Slider {
volume=50;
}
