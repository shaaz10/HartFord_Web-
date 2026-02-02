import { Injectable, signal, computed } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  // allowed operators (IMPORTANT for type safety)
  readonly operators = ['+', '-', '*', '/'] as const;

  numA = signal<number>(0);
  numB = signal<number>(0);
  operator = signal<'+' | '-' | '*' | '/'>('+');

  total = computed<number | string>(() => {
    const a = this.numA();
    const b = this.numB();

    switch (this.operator()) {
      case '+': return a + b;
      case '-': return a - b;
      case '*': return a * b;
      case '/': return b === 0 ? 'Error (Div by 0)' : a / b;
      default: return 0;
    }
  });

  reset() {
    this.numA.set(0);
    this.numB.set(0);
    this.operator.set('+');
  }
}
