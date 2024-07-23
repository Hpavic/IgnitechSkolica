import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Grade {
  id: number;
  value: number;
  createdOn: Date;
  gradeText: string;
  gradeNumber: number;
}

export interface AverageGrade {
  averageValue: number;
  gradeText: string;
  gradeNumber: number;
}

@Injectable({
  providedIn: 'root'
})
export class GradeService {
  private apiUrl = 'http://localhost:5090/api/Grade';

  constructor(private http: HttpClient) { }

  getGradesByStudentAndSubject(studentCode: string, subjectId: number): Observable<Grade[]> {
    console.log(`Requesting grades for studentCode: ${studentCode} and subjectId: ${subjectId}`);
    return this.http.get<{ $values: Grade[] }>(`${this.apiUrl}/Student/${studentCode}/Subject/${subjectId}/Grades`).pipe(
      map(response => {
        console.log('Fetched grades from API:', response.$values);
        return response.$values;
      })
    );
  }

  getAverageGradeByStudentAndSubject(studentCode: string, subjectId: number): Observable<AverageGrade> {
    console.log(`Requesting average grade for studentCode: ${studentCode} and subjectId: ${subjectId}`);
    return this.http.get<AverageGrade>(`${this.apiUrl}/Student/${studentCode}/Subject/${subjectId}/AverageGrade`).pipe(
      map(response => {
        console.log('Fetched average grade from API:', response);
        return response;
      })
    );
  }
}
