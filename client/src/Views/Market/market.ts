import { Component } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonModule } from '@angular/material/button';

export interface MarketRow {
  commodity: string;
  price: number;
  change: number;
  volume: string;
  status: 'active' | 'halted';
}

@Component({
  selector: 'app-market',
  imports: [
    DecimalPipe,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatChipsModule,
    MatButtonModule,
  ],
  templateUrl: './market.html',
  styleUrl: './market.scss',
})
export class MarketComponent {
  readonly displayedColumns = ['commodity', 'price', 'change', 'volume', 'status'];

  readonly dataSource: MarketRow[] = [
    { commodity: 'Natural Gas', price: 2.84, change: 1.43, volume: '2.1M', status: 'active' },
    {
      commodity: 'Electricity (PJM)',
      price: 45.2,
      change: -0.88,
      volume: '850K',
      status: 'active',
    },
    { commodity: 'Crude Oil (WTI)', price: 78.34, change: 0.62, volume: '4.5M', status: 'active' },
    { commodity: 'Coal (API2)', price: 115.0, change: -2.1, volume: '320K', status: 'halted' },
    { commodity: 'Carbon Credits', price: 68.75, change: 3.2, volume: '1.2M', status: 'active' },
  ];
}
