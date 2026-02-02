import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  // private data
  private messages: string[] = [
    'Hello Angular',
    'Welcome to Services',
    'Dependency Injection works!'
  ];

  // returns data
  getData(): string[] {
    return this.messages;
  }

  // adds new message
  addData(message: string): void {
    if (message.trim()) {
      this.messages.push(message);
    }
  }
}
