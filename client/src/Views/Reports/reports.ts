import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';

interface Report {
  name: string;
  description: string;
  lastRun: string;
  frequency: string;
  icon: string;
}

@Component({
  selector: 'app-reports',
  imports: [
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule,
    MatDividerModule,
    MatTooltipModule,
  ],
  templateUrl: './reports.html',
  styleUrl: './reports.scss',
})
export class ReportsComponent {
  readonly reports: Report[] = [
    {
      name: 'Daily Risk Summary',
      description: 'VaR, exposure and limit utilization summary',
      lastRun: 'Today, 08:00',
      frequency: 'Daily',
      icon: 'shield',
    },
    {
      name: 'Trading Blotter',
      description: 'All confirmed and pending trades for the day',
      lastRun: 'Today, 07:45',
      frequency: 'Daily',
      icon: 'receipt_long',
    },
    {
      name: 'P&L Attribution',
      description: 'Profit and loss broken down by commodity and desk',
      lastRun: 'Yesterday',
      frequency: 'Daily',
      icon: 'trending_up',
    },
    {
      name: 'Counterparty Exposure',
      description: 'Credit exposure aggregated by counterparty',
      lastRun: '2 days ago',
      frequency: 'Weekly',
      icon: 'groups',
    },
    {
      name: 'Regulatory Compliance',
      description: 'CFTC and FERC reporting obligations',
      lastRun: 'Mar 15, 2026',
      frequency: 'Monthly',
      icon: 'gavel',
    },
  ];
}
