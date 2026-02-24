import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../core/services/auth';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './login.html'
})
export class Login implements OnInit {

  private auth = inject(AuthService);
  private router = inject(Router);

  loading = false;
  error = '';

  loginForm = {
    email: '',
    password: ''
  };

  // ✅ CAPTCHA variables
  captchaQuestion = '';
  captchaAnswer: number = 0;
  userCaptcha = '';

  ngOnInit() {
    this.generateCaptcha();
  }

  generateCaptcha() {
    const num1 = Math.floor(Math.random() * 10) + 1;
    const num2 = Math.floor(Math.random() * 10) + 1;
    const operators = ['+', '-', '*'];

    const operator = operators[Math.floor(Math.random() * operators.length)];

    switch (operator) {
      case '+':
        this.captchaAnswer = num1 + num2;
        break;
      case '-':
        this.captchaAnswer = num1 - num2;
        break;
      case '*':
        this.captchaAnswer = num1 * num2;
        break;
    }

    this.captchaQuestion = `${num1} ${operator} ${num2} = ?`;
    this.userCaptcha = '';
  }

  login() {

    // ✅ CAPTCHA validation (added safely)
    if (Number(this.userCaptcha) !== this.captchaAnswer) {
      this.error = 'Invalid CAPTCHA answer';
      this.generateCaptcha();
      return;
    }

    this.loading = true;
    this.error = '';

    this.auth.login(this.loginForm).subscribe({
      next: (res) => {
        this.loading = false;

        // ✅ Save JWT
        this.auth.saveToken(res.token);

        // ✅ Extract Role
        const role = this.auth.getUserRole();

        // ✅ Navigate by role
        if (role === 'Admin') {
          this.router.navigate(['/admin']);
        }
        else if (role === 'Trainer') {
          this.router.navigate(['/trainer']);
        }
        else if (role === 'Student') {
          this.router.navigate(['/student']);
        }
        else {
          this.error = 'Unknown user role';
        }
      },
      error: (err) => {
        this.loading = false;
        this.error = err.error?.message || 'Invalid credentials';
        this.generateCaptcha(); // regenerate on failure
      }
    });
  }
}