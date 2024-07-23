import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Subject, Teacher } from './teacher.service';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private apiUrl = 'http://localhost:5090/api/Subject';

  constructor(private http: HttpClient) { }

  getAllSubjects(): Observable<Subject[]> {
    return this.http.get<{ $values: Subject[] }>(`${this.apiUrl}`).pipe(
      map(response => {
        console.log('Fetched subjects from API:', response);
        return response.$values;
      })
    );
  }

  getTeacherByStudentAndSubject(studentCode: string, subjectId: number): Observable<Teacher> {
    console.log(`Requesting teacher for studentCode: ${studentCode} and subjectId: ${subjectId}`);
    return this.http.get<Teacher>(`${this.apiUrl}/Student/${studentCode}/Subject/${subjectId}/Teacher`).pipe(
      map(response => {
        console.log('Fetched teacher from API:', response);
        return response;
      })
    );
  }
}
