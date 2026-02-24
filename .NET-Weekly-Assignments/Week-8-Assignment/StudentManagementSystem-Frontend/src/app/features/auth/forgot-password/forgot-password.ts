import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './forgot-password.html'
})
export class ForgotPassword {

  private auth = inject(AuthService);
  private router = inject(Router);

  step = 1;

  email = '';
  securityQuestion = '';
  securityAnswer = '';
  newPassword = '';

  message = '';
  error = '';

  // Step 1: Request Security Question
  getQuestion() {
    this.message = '';
    this.error = '';

    if (!this.email) {
      this.error = "Please enter your email.";
      return;
    }

    this.auth.getSecurityQuestion(this.email).subscribe({
      next: (res: any) => {
        this.securityQuestion = res.question;
        this.step = 2;
      },
      error: (err: any) => {
        this.error = err.error?.message || 'Something went wrong';
      }
    });
  }

  // Step 2: Answer & Reset
  resetPassword() {
    this.message = '';
    this.error = '';

    if (!this.securityAnswer || !this.newPassword) {
      this.error = "Please answer the question and enter a new password.";
      return;
    }

    const payload = {
      email: this.email,
      securityAnswer: this.securityAnswer,
      newPassword: this.newPassword
    };

    this.auth.resetPassword(payload).subscribe({
      next: (res: any) => {
        alert('✅ Password reset successful! You can now log in.');
        this.router.navigate(['/login']);
      },
      error: (err: any) => {
        this.error = err.error?.message || 'Failed to reset password';
      }
    });
  }
}