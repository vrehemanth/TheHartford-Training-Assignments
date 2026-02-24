import { Component, OnInit, ChangeDetectorRef, inject } from '@angular/core';
import { Trainer } from '../../core/services/trainer';
import { Navbar } from '../../shared/navbar/navbar';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-trainer-dashboard',
  standalone: true,
  imports: [Navbar, CommonModule, FormsModule],
  templateUrl: './trainer-dashboard.html',
})
export class TrainerDashboard implements OnInit {

  students: any[] = [];
  materials: any[] = [];

  activeBatches = 0;
  pendingReviews = 0;

  selectedStudent: any = null;
  editingStudent: any = null;
  updatedProgress = 0;

  showMaterialModal = false;
  editingMaterial: any = null;
  showFeedbackModal: boolean = false;
  selectedMaterial: any = null;
  material: { title: string, description: string, url: string } = {
    title: '',
    description: '',
    url: ''
  };

  trainerFeedbacks: any[] = [];
  feedbackStudent: any = null;

  feedback = {
    studentId: '',
    materialId: '',
    comments: '',
    rating: 1
  };

  private trainerService = inject(Trainer);
  private cdr = inject(ChangeDetectorRef);

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard() {
    this.loadStudents();
    this.loadStats();
    this.loadMaterials();
    this.loadFeedback();
  }
  loadFeedback() {
    this.trainerService.getTrainerFeedback().subscribe(res => {
      this.trainerFeedbacks = res ?? [];
    });
  }

  getStudentFeedback(studentName: string): any[] {
    return this.trainerFeedbacks.filter(f => f.studentName === studentName);
  }
  // ✅ STUDENTS
  loadStudents() {
    this.trainerService.getAssignedStudents().subscribe(res => {
      this.students = res ?? [];
      this.cdr.detectChanges();
    });
  }

  // ✅ STATS
  loadStats() {
    this.trainerService.getTrainerStats().subscribe(res => {
      this.activeBatches = res?.activeBatches ?? 0;
      this.pendingReviews = res?.pendingReviews ?? 0;
      this.cdr.detectChanges();
    });
  }

  // ✅ MATERIALS
  loadMaterials() {
    this.trainerService.getMaterials().subscribe(res => {
      this.materials = res ?? [];
      this.cdr.detectChanges();
    });
  }

  // ✅ VIEW STUDENT
  viewStudent(student: any) {
    this.selectedStudent = student;
  }

  closeView() {
    this.selectedStudent = null;
  }


  // ✅ EDIT PROGRESS
  editProgress(student: any) {
    this.editingStudent = student;
    this.updatedProgress = student.progress ?? 0;
  }

  closeEdit() {
    this.editingStudent = null;
  }

  saveProgress() {
    if (!this.editingStudent) return;

    this.trainerService.updateStudentProgress(
      this.editingStudent.id,
      this.updatedProgress
    ).subscribe(() => {
      this.editingStudent.progress = this.updatedProgress;
      alert('✅ Progress updated');
      this.closeEdit();
      this.cdr.detectChanges();
    });
  }

  // ✅ MATERIAL MODAL
  openMaterialModal() {
    this.showMaterialModal = true;
    this.editingMaterial = null;
    this.resetMaterial();
  }

  closeMaterialModal() {
    this.showMaterialModal = false;
  }

  addMaterial() {
    this.trainerService.addStudyMaterial(this.material).subscribe(() => {
      alert('✅ Material added');
      this.closeMaterialModal();
      this.loadMaterials();
    }, err => {
      alert('Failed to add material');
    });
  }

  editMaterial(m: any) {
    this.editingMaterial = m;
    // Map URL correctly
    this.material = { title: m.title, description: m.description, url: m.url };
    this.showMaterialModal = true;
  }

  updateMaterial() {
    this.trainerService.updateStudyMaterial(
      this.editingMaterial.id,
      this.material
    ).subscribe(() => {
      alert('✅ Material updated');
      this.closeMaterialModal();
      this.loadMaterials();
    }, err => {
      alert('Failed to update material');
    });
  }

  deleteMaterial(m: any) {
    if (!confirm('Delete material?')) return;

    this.trainerService.deleteStudyMaterial(m.id).subscribe(() => {
      alert('🗑 Material deleted');
      this.loadMaterials();
    });
  }

  viewMaterial(m: any) {
    if (m.url) {
      window.open(m.url, '_blank');
    } else {
      alert('Material link is missing');
    }
  }

  resetMaterial() {
    this.material = { title: '', description: '', url: '' };
  }

  // ✅ FEEDBACK
  openFeedbackModal(student: any) {
    this.feedbackStudent = student;
    this.feedback.studentId = student.id;
    this.feedback.materialId = '';
    this.feedback.comments = '';
    this.feedback.rating = 5;
    this.showFeedbackModal = true;
  }

  closeFeedbackModal() {
    this.showFeedbackModal = false;
    this.feedbackStudent = null;
  }

  submitFeedback() {
    if (!this.feedback.comments) {
      alert('Please enter a comment');
      return;
    }

    // Create a payload with only what we need to avoid 400 Bad Request
    // Since we disabled material and rating, sending empty strings for Guid might crash ASP.NET Core
    const payload = {
      studentId: this.feedback.studentId,
      comments: this.feedback.comments
    };

    this.trainerService.addFeedback(payload).subscribe(() => {
      alert('✅ Feedback submitted');
      this.closeFeedbackModal();
      this.loadFeedback();
    }, err => {
      alert('Failed to submit feedback');
    });
  }
}