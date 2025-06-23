import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'dashboard', loadComponent: () => import('./pages/dashboard/dashboard.component').then(m => m.DashboardComponent) },
  { path: 'tasks', loadComponent: () => import('./pages/task-list/task-list.component').then(m => m.TaskListComponent) },
  { path: 'task-form', loadComponent: () => import('./pages/task-form/task-form.component').then(m => m.TaskFormComponent) },
  { path: 'task-form/:id', loadComponent: () => import('./pages/task-form/task-form.component').then(m => m.TaskFormComponent) },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];
