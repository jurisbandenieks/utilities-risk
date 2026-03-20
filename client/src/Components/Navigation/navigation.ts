import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

interface NavItem {
  label: string;
  route: string;
  icon: string;
}

@Component({
  selector: 'app-navigation',
  imports: [RouterLink, RouterLinkActive, MatListModule, MatIconModule, MatDividerModule],
  templateUrl: './navigation.html',
  styleUrl: './navigation.scss',
})
export class NavigationComponent {
  readonly navItems: NavItem[] = [
    { label: 'Dashboard', route: '/dashboard', icon: 'dashboard' },
    { label: 'Market', route: '/market', icon: 'trending_up' },
    { label: 'Risk', route: '/risk', icon: 'shield' },
    { label: 'Trading', route: '/trading', icon: 'swap_horiz' },
    { label: 'Reports', route: '/reports', icon: 'bar_chart' },
    { label: 'Admin', route: '/admin', icon: 'manage_accounts' },
  ];
}
