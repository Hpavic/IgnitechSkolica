import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Teacher {
  id: number;
  firstName: string;
  lastName: string;
  teacherCode: string;
}

export interface Student {
  id: number;
  firstName: string;
  lastName: string;
  studentCode: string;
}

export interface Subject {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private apiUrl = 'http://localhost:5090/api/Teacher';

  constructor(private http: HttpClient) { }

  getAllTeachers(): Observable<Teacher[]> {
    return this.http.get<{ $values: Teacher[] }>(`${this.apiUrl}`).pipe(
      map(response => response.$values)
    );
  }

  getStudentsByTeacherCode(teacherCode: string): Observable<Student[]> {
    return this.http.get<{ $values: Student[] }>(`${this.apiUrl}/Students/${teacherCode}`).pipe(
      map(response => response.$values)
    );
  }

  getSubjectsByTeacherCode(teacherCode: string): Observable<Subject[]> {
    return this.http.get<{ $values: Subject[] }>(`${this.apiUrl}/Subjects/${teacherCode}`).pipe(
      map(response => response.$values)
    );
  }
}
