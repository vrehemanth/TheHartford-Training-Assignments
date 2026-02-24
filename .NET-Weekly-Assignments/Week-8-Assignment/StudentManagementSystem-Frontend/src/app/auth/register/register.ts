import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './register.html'
})
export class Register implements OnInit {

  private auth = inject(AuthService);
  private router = inject(Router);

  error = '';
  loading = false;

  courses: string[] = [];

  registerForm: any = {
    fullName: '',
    email: '',
    password: '',
    userRole: 'Student',
    course: '',
    expertise: '',
    securityQuestion: '',
    securityAnswer: ''
  };

  securityQuestions = [
    "What was the name of your first pet?",
    "What city were you born in?",
    "What is your mother's maiden name?",
    "What was the make of your first car?",
    "What is your favorite book?"
  ];

  ngOnInit(): void {
    this.loadCourses();
  }

  // ✅ LOAD COURSES FROM API
  loadCourses() {
    this.auth.getCourses().subscribe({
      next: (res) => {
        this.courses = res;
      },
      error: () => {
        // Warning suppressed
      }
    });
  }

  register() {
    this.loading = true;
    this.error = '';

    this.auth.register(this.registerForm).subscribe({
      next: () => {
        this.loading = false;

        alert('✅ Registration successful');

        this.router.navigate(['/login'], {
          state: { email: this.registerForm.email }
        });
      },
      error: (err) => {
        this.loading = false;

        if (err.error?.errors) {
          // Flatten ASP.NET Core ValidationProblemDetails
          const messages = Object.values(err.error.errors).flat();
          this.error = messages.join(' | ');
        } else {
          this.error = err.error?.message || typeof err.error === 'string' ? err.error : 'Registration failed. See console for details.';
        }
      }
    });
  }
}