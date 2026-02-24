import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Admin {
  private http = inject(HttpClient);
  api = 'https://localhost:7269/api/admin';

  getStats() {
    return this.http.get<any>(`${this.api}/dashboard-stats`);
  }
  getAllStudents() {
    return this.http.get<any[]>(`${this.api}/students`);
  }
  getAllTrainers() {
    return this.http.get<any[]>(`${this.api}/trainers`);
  }

  deleteTrainer(id: string) {
    return this.http.delete(`${this.api}/trainer/${id}`);
  }

  deleteStudent(id: string) {
    return this.http.delete(`${this.api}/student/${id}`);
  }

  assignTrainerToStudent(trainerId: string, studentId: string) {
    return this.http.post(`${this.api}/assign-trainer`, {
      trainerId,
      studentId
    });
  }

  getStudentFeedbacks(studentId: string) {
    return this.http.get<any[]>(`${this.api}/student/${studentId}/feedbacks`);
  }
}
