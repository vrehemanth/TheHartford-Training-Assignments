import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Navbar } from '../../shared/navbar/navbar';
import { Admin } from '../../core/services/admin';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, Navbar],
  templateUrl: './admin-dashboard.html'
})
export class AdminDashboard implements OnInit {

  private adminService = inject(Admin);
  private cdr = inject(ChangeDetectorRef);

  stats: any = {
    totalStudents: 0,
    totalTrainers: 0,
    totalMaterials: 0,
    totalFeedbacks: 0
  };

  recentStudents: any[] = [];
  students: any[] = [];
  trainers: any[] = [];

  selectedTrainerId = '';
  selectedStudentId = '';

  selectedStudentForFeedback: any = null;
  studentFeedbacks: any[] = [];
  showFeedbackModal = false;

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard() {

    // ✅ Stats
    this.adminService.getStats().subscribe(res => {
      this.stats = res;
      this.cdr.detectChanges();
    });

    // All Students
    this.adminService.getAllStudents().subscribe(res => {
      this.students = res;
      this.cdr.detectChanges();
    });
    // ✅ All trainers
    this.adminService.getAllTrainers().subscribe(res => {
      this.trainers = res;
      this.cdr.detectChanges();
    });
  }

  // ✅ Remove Trainer
  removeTrainer(id: string) {
    if (!confirm('Remove this trainer?')) return;

    this.adminService.deleteTrainer(id).subscribe({
      next: () => {
        // ✅ Remove from UI instantly
        this.trainers = this.trainers.filter(t => t.id !== id);

        // ✅ Also unassign students trained by this trainer (optional)
        this.students = this.students.map(s => {
          if (s.trainerId === id) {
            return { ...s, trainerId: null, trainerName: null };
          }
          return s;
        });

        // ✅ Fetch the latest stats to update the materials and feedbacks counts
        this.adminService.getStats().subscribe(res => {
          this.stats = res;
          this.cdr.detectChanges();
        });

        this.cdr.detectChanges();
      },
      error: err => {
        // Handle error silently
      }
    });
  }

  // ✅ Remove Student
  removeStudent(id: string) {
    if (!confirm('Remove this student?')) return;

    this.adminService.deleteStudent(id).subscribe({
      next: () => {
        // ✅ Remove from UI instantly
        this.students = this.students.filter(s => s.id !== id);

        // ✅ Fetch the latest stats to update materials and feedbacks counts
        this.adminService.getStats().subscribe(res => {
          this.stats = res;
          this.cdr.detectChanges();
        });

        this.cdr.detectChanges();
      },
      error: err => {
        // Handle error silently
      }
    });
  }

  // ✅ Assign Trainer → Student
  assignTrainer() {
    if (!this.selectedTrainerId || !this.selectedStudentId) {
      alert('Please select trainer and student');
      return;
    }

    this.adminService.assignTrainerToStudent(
      this.selectedTrainerId,
      this.selectedStudentId
    ).subscribe({
      next: () => {

        // ✅ Update UI instantly
        const trainer = this.trainers.find(t => t.id === this.selectedTrainerId);

        this.students = this.students.map(s => {
          if (s.id === this.selectedStudentId) {
            return {
              ...s,
              trainerId: this.selectedTrainerId,
              trainerName: trainer?.fullName
            };
          }
          return s;
        });

        alert('Trainer assigned successfully');
        this.cdr.detectChanges();
      },
      error: err => {
        // Handle error silently
      }
    });
  }

  // ✅ View Feedback
  viewFeedback(student: any) {
    this.selectedStudentForFeedback = student;
    this.showFeedbackModal = true;
    this.studentFeedbacks = []; // Reset while loading

    this.adminService.getStudentFeedbacks(student.id).subscribe({
      next: (res) => {
        this.studentFeedbacks = res;
        this.cdr.detectChanges();
      },
      error: (err) => {
        // Handle error silently
      }
    });
  }

  closeFeedbackModal() {
    this.showFeedbackModal = false;
    this.selectedStudentForFeedback = null;
    this.studentFeedbacks = [];
  }
}