import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';

interface RiskMetric {
  label: string;
  value: string;
  limit: string;
  utilization: number;
  severity: 'low' | 'medium' | 'high';
}

@Component({
  selector: 'app-risk',
  imports: [MatCardModule, MatIconModule, MatProgressBarModule, MatButtonModule, MatDividerModule],
  templateUrl: './risk.html',
  styleUrl: './risk.scss',
})
export class RiskComponent {
  readonly metrics: RiskMetric[] = [
    {
      label: 'Value at Risk (1d, 95%)',
      value: '$2.4M',
      limit: '$5M',
      utilization: 48,
      severity: 'low',
    },
    {
      label: 'Credit Exposure',
      value: '$18.7M',
      limit: '$25M',
      utilization: 75,
      severity: 'medium',
    },
    { label: 'Commodity Delta', value: '$9.1M', limit: '$10M', utilization: 91, severity: 'high' },
    {
      label: 'Open Position Limit',
      value: '105 MW',
      limit: '150 MW',
      utilization: 70,
      severity: 'medium',
    },
    { label: 'Counterparty Limit', value: '$3.2M', limit: '$8M', utilization: 40, severity: 'low' },
  ];
}
