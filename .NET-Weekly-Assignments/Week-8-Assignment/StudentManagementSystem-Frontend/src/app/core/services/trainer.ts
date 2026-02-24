import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class Trainer {

  private baseUrl = 'https://localhost:7269/api/trainer';

  constructor(private http: HttpClient) {}

  // ✅ Students
  getAssignedStudents(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/students`);
  }

  // ✅ Stats
  getTrainerStats(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/stats`);
  }
  getTrainerFeedback() {
    return this.http.get<any[]>(`${this.baseUrl}/feedback`);
  }
  // ✅ Progress (GUID)
  updateStudentProgress(studentId: string, progress: number) {
    return this.http.put(`${this.baseUrl}/progress/${studentId}`, { progress });
  }

  
  // ✅ Materials
  getMaterials(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/materials`);
  }

  addStudyMaterial(data: any) {
    return this.http.post(`${this.baseUrl}/materials`, data);
  }

  updateStudyMaterial(id: string, data: any) {
    return this.http.put(`${this.baseUrl}/materials/${id}`, data);
  }

  deleteStudyMaterial(id: string) {
    return this.http.delete(`${this.baseUrl}/materials/${id}`);
  }

  // ✅ Feedback
  addFeedback(data: any) {
    return this.http.post(`${this.baseUrl}/feedback`, data);
  }
}