import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'login',
    loadComponent: () => import('../Views/Login/login').then((m) => m.LoginComponent),
  },
  {
    path: 'dashboard',
    loadComponent: () => import('../Views/Dashboard/dashboard').then((m) => m.DashboardComponent),
  },
  {
    path: 'admin',
    loadComponent: () => import('../Views/Admin/admin').then((m) => m.AdminComponent),
  },
  {
    path: 'market',
    loadComponent: () => import('../Views/Market/market').then((m) => m.MarketComponent),
  },
  {
    path: 'risk',
    loadComponent: () => import('../Views/Risk/risk').then((m) => m.RiskComponent),
  },
  {
    path: 'trading',
    loadComponent: () => import('../Views/Trading/trading').then((m) => m.TradingComponent),
  },
  {
    path: 'reports',
    loadComponent: () => import('../Views/Reports/reports').then((m) => m.ReportsComponent),
  },
  {
    path: '**',
    loadComponent: () => import('../Views/NotFound/not-found').then((m) => m.NotFoundComponent),
  },
];
