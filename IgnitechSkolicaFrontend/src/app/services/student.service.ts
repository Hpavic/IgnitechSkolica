import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Student, Subject } from './teacher.service';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'http://localhost:5090/api/Student';

  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<Student[]> {
    return this.http.get<{ $values: Student[] }>(`${this.apiUrl}`).pipe(
      map(response => response.$values)
    );
  }

  getSubjectsByStudentCode(studentCode: string): Observable<Subject[]> {
    return this.http.get<{ $values: Subject[] }>(`${this.apiUrl}/Subjects/${studentCode}`).pipe(
      map(response => response.$values)
    );
  }
}
