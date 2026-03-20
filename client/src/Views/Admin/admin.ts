import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';

interface User {
  name: string;
  email: string;
  role: string;
  status: 'active' | 'inactive';
  initials: string;
}

@Component({
  selector: 'app-admin',
  imports: [
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule,
    MatDividerModule,
  ],
  templateUrl: './admin.html',
  styleUrl: './admin.scss',
})
export class AdminComponent {
  readonly users: User[] = [
    {
      name: 'Sarah Mitchell',
      email: 'smitchell@utilrisk.com',
      role: 'Risk Manager',
      status: 'active',
      initials: 'SM',
    },
    {
      name: 'James Hartley',
      email: 'jhartley@utilrisk.com',
      role: 'Trader',
      status: 'active',
      initials: 'JH',
    },
    {
      name: 'Elena Vasquez',
      email: 'evasquez@utilrisk.com',
      role: 'Analyst',
      status: 'active',
      initials: 'EV',
    },
    {
      name: 'Tom Brennan',
      email: 'tbrennan@utilrisk.com',
      role: 'Compliance',
      status: 'inactive',
      initials: 'TB',
    },
  ];
}
