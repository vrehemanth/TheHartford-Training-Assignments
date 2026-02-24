import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { Login } from './auth/login/login';
import { Register } from './auth/register/register';
import { AdminDashboard } from './dashboards/admin-dashboard/admin-dashboard';
import { TrainerDashboard } from './dashboards/trainer-dashboard/trainer-dashboard';
import { StudentDashboard } from './dashboards/student-dashboard/student-dashboard';
import { authGuard } from './core/guards/auth-guard';
import { ForgotPassword } from './features/auth/forgot-password/forgot-password';
import { ResetPassword } from './features/auth/reset-password/reset-password';

export const routes: Routes = [
  { path: '', component: Home },

  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'forgot-password', component: ForgotPassword },
  { path: 'reset-password', component: ResetPassword },
  {
    path: 'admin',
    component: AdminDashboard,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
    path: 'trainer',
    component: TrainerDashboard,
    canActivate: [authGuard],
    data: { role: 'Trainer' }
  },
  {
    path: 'student',
    component: StudentDashboard,
    canActivate: [authGuard],
    data: { role: 'Student' }
  }
];