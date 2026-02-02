import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CalculatorService } from '../../app/services/calculator';

@Component({
  selector: 'app-calc',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calc.html',
  styleUrl: './calc.css',
})
export class Calc {
  protected calc = inject(CalculatorService);
}
