import { Component,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  imports: [],
  templateUrl: './child.html',
  styleUrl: './child.css',
})
export class Child {
  @Output() dataChanged=new EventEmitter<string>();
  sendDataToParent(data:string){
    this.dataChanged.emit(data);
  }
}
