import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService {

  private http = inject(HttpClient);
  private router = inject(Router);

  private apiUrl = 'https://localhost:7269/api/auth';

  // ✅ LOGIN
  login(credentials: any) {
    return this.http.post<any>(`${this.apiUrl}/login`, credentials);
  }

  // ✅ REGISTER
  register(data: any) {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  getSecurityQuestion(email: string) {
    return this.http.get<any>(`${this.apiUrl}/security-question?email=${encodeURIComponent(email)}`);
  }

  resetPassword(payload: any) {
    return this.http.post(`${this.apiUrl}/reset-password`, payload);
  }
  // ✅ COURSES API
  getCourses() {
    return this.http.get<string[]>('https://localhost:7269/api/student/courses');
  }

  // ✅ TOKEN STORAGE
  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  // ✅ ROLE FROM JWT
  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));

    return payload['role'] ||
      payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ||
      null;
  }
}