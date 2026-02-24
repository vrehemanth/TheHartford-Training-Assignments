import { Component, OnInit, ChangeDetectorRef, inject } from '@angular/core';
import { Navbar } from '../../shared/navbar/navbar';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../../core/services/student';

@Component({
  selector: 'app-student-dashboard',
  standalone: true,
  imports: [Navbar, CommonModule, FormsModule],
  templateUrl: './student-dashboard.html',
})
export class StudentDashboard implements OnInit {

  materials: any[] = [];

  selectedMaterial: any = null;
  showFeedbackModal: boolean = false;
  feedback = {
    materialId: '',
    comments: '',
    rating: 5
  };

  private studentService = inject(StudentService);
  private cdr = inject(ChangeDetectorRef);

  ngOnInit(): void {
    this.loadMaterials();
    this.loadFeedbacks();
  }

  // ✅ Load Materials
  loadMaterials() {
    this.studentService.getMaterials().subscribe({
      next: (res) => {
        this.materials = res ?? [];
        this.cdr.detectChanges();
      },
      error: (err) => {
        // Handle error silently
      }
    });
  }

  feedbacks: any[] = [];

  loadFeedbacks() {
    this.studentService.getMyFeedback().subscribe({
      next: (res) => {
        this.feedbacks = res ?? [];
        this.cdr.detectChanges(); // force UI refresh
      }
    });
  }
}