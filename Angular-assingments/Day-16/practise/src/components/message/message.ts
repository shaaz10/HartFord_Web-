import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MessageService } from '../../app/services/messageservice';

@Component({
  selector: 'app-message',
  standalone: true,
  imports: [CommonModule, FormsModule,MessageComponent],
  templateUrl: './message.html'
})
export class MessageComponent {

  private messageService = inject(MessageService);

  messages: string[] = [];
  newMessage: string = '';

  constructor() {
    this.messages = this.messageService.getData();
  }

  addMessage(): void {
    this.messageService.addData(this.newMessage);
    this.newMessage = '';
  }
}
