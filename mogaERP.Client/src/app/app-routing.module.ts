import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { authGuard } from './core/guards/auth.guard';
import { DashboardComponent } from './features/dashboard/dashboard.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent , canActivate: [authGuard] },
  { path: 'purchases', loadChildren: () => import('./features/purchases/purchases.module').then(m => m.PurchasesModule) },
  { path: 'system-settings', loadChildren: () => import('./features/system-settings/system-settings.module').then(m => m.SystemSettingsModule) },
  { path: 'task-mangment', loadChildren: () => import('./features/task-mangment/task-mangment.module').then(m => m.TaskMangmentModule) },
  { path:'**', redirectTo: '/dashboard'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
