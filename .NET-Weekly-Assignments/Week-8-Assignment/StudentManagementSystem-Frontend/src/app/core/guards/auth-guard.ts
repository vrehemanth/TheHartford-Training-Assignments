import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth';

export const authGuard = (route: any) => {

  const auth = inject(AuthService);
  const router = inject(Router);

  const token = auth.getToken();
  const expectedRole = route.data?.['role'];

  if (!token) {
    router.navigate(['/login']);
    return false;
  }

  const role = auth.getUserRole();

  if (expectedRole && role !== expectedRole) {
    router.navigate(['/login']);
    return false;
  }

  return true;
};