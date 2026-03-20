import { Component } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

export interface Trade {
  id: string;
  commodity: string;
  direction: 'BUY' | 'SELL';
  quantity: number;
  price: number;
  counterparty: string;
  status: 'confirmed' | 'pending' | 'cancelled';
}

@Component({
  selector: 'app-trading',
  imports: [
    DecimalPipe,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatChipsModule,
    MatButtonModule,
    MatTooltipModule,
  ],
  templateUrl: './trading.html',
  styleUrl: './trading.scss',
})
export class TradingComponent {
  readonly displayedColumns = [
    'id',
    'commodity',
    'direction',
    'quantity',
    'price',
    'counterparty',
    'status',
  ];

  readonly trades: Trade[] = [
    {
      id: 'TRD-001',
      commodity: 'Natural Gas',
      direction: 'BUY',
      quantity: 10000,
      price: 2.84,
      counterparty: 'Vertex Energy',
      status: 'confirmed',
    },
    {
      id: 'TRD-002',
      commodity: 'Electricity',
      direction: 'SELL',
      quantity: 50,
      price: 45.2,
      counterparty: 'NextEra',
      status: 'confirmed',
    },
    {
      id: 'TRD-003',
      commodity: 'Crude Oil',
      direction: 'BUY',
      quantity: 1000,
      price: 78.34,
      counterparty: 'BP Trading',
      status: 'pending',
    },
    {
      id: 'TRD-004',
      commodity: 'Carbon Credits',
      direction: 'BUY',
      quantity: 500,
      price: 68.75,
      counterparty: 'Shell Energy',
      status: 'pending',
    },
    {
      id: 'TRD-005',
      commodity: 'Coal API2',
      direction: 'SELL',
      quantity: 2000,
      price: 115.0,
      counterparty: 'Glencore',
      status: 'cancelled',
    },
  ];
}
