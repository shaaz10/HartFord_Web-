import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statuspipe',
})
export class StatuspipePipe implements PipeTransform {

transform(orderId: number): string {
    switch (orderId) {
      case 1:
        return 'Pending';
      case 2:
        return 'Shipped';
      case 3:
        return 'Delivered';
      case 4:
        return 'Cancelled';
      case 5:
        return 'Unknown';
      default:
        return 'Unknown';
    }
  }

}
