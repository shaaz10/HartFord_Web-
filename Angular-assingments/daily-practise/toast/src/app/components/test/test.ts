import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-test',
  standalone: true,
  template: `
    <div class="p-6 space-x-3">
      <button
        class="bg-green-600 text-white px-4 py-2 rounded"
        (click)="success()"
      >
        Success
      </button>

      <button
        class="bg-red-600 text-white px-4 py-2 rounded"
        (click)="error()"
      >
        Error
      </button>
    </div>
  `,
})
export class TestComponent {
  constructor(private toastr: ToastrService) {}

  success() {
    this.toastr.success(
      'Angular 21 + Tailwind works 🚀',
      'Success'
    );
  }

  error() {
    this.toastr.error(
      'Something went wrong ❌',
      'Error'
    );
  }
}
