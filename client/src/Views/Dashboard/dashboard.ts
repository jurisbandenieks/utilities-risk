import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';

interface StatCard {
  label: string;
  value: string;
  change: string;
  positive: boolean;
  icon: string;
}

@Component({
  selector: 'app-dashboard',
  imports: [MatCardModule, MatIconModule, MatButtonModule, MatDividerModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class DashboardComponent {
  readonly stats: StatCard[] = [
    {
      label: 'Total Positions',
      value: '142',
      change: '+4 today',
      positive: true,
      icon: 'account_balance_wallet',
    },
    {
      label: 'Portfolio P&L',
      value: '$1,284,560',
      change: '+2.3%',
      positive: true,
      icon: 'trending_up',
    },
    { label: 'Risk Exposure', value: '$48.2M', change: '-1.1%', positive: false, icon: 'shield' },
    { label: 'Active Trades', value: '37', change: '+5 today', positive: true, icon: 'swap_horiz' },
  ];
}
