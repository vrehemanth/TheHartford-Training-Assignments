import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StudentService {

  private baseUrl = 'https://localhost:7269/api/student';

  constructor(private http: HttpClient) {}

  // ✅ Get Study Materials
  getMaterials(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/study-materials`);
  }
  getMyFeedback() {
    return this.http.get<any[]>(`${this.baseUrl}/feedback`);
  }
  // ✅ Submit Feedback
  submitFeedback(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/feedback`, data);
  }
}