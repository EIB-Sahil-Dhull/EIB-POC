import { Component } from '@angular/core';
import { UserListComponent } from './user-list/user-list.component';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,RouterOutlet,FormsModule,ReactiveFormsModule,UserListComponent],
  template: `
    
    <app-user-list></app-user-list> 
  `,
})


export class AppComponent {}
