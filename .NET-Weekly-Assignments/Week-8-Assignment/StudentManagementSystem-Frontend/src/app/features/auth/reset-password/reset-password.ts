import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth';

@Component({
    selector: 'app-reset-password',
    standalone: true,
    imports: [FormsModule, CommonModule, RouterModule],
    templateUrl: './reset-password.html'
})
export class ResetPassword implements OnInit {

    private auth = inject(AuthService);
    private route = inject(ActivatedRoute);

    email = '';
    token = '';
    newPassword = '';
    confirmPassword = '';

    message = '';
    error = '';

    ngOnInit() {
        this.route.queryParams.subscribe(params => {
            this.email = params['email'] || '';
            this.token = params['token'] || '';

            if (!this.email || !this.token) {
                this.error = 'Invalid reset link. Missing parameters.';
            }
        });
    }

    submit() {
        this.message = '';
        this.error = '';

        if (!this.email || !this.token) {
            this.error = 'Invalid reset link.';
            return;
        }

        if (this.newPassword !== this.confirmPassword) {
            this.error = 'Passwords do not match.';
            return;
        }

        if (this.newPassword.length < 6) {
            this.error = 'Password must be at least 6 characters.';
            return;
        }

        const payload = {
            email: this.email,
            token: this.token,
            newPassword: this.newPassword
        };

        this.auth.resetPassword(payload).subscribe({
            next: (res: any) => {
                this.message = 'Password has been set successfully!';
            },
            error: (err: any) => {
                this.error = err.error?.message || err.error || 'Failed to reset password';
            }
        });
    }
}
