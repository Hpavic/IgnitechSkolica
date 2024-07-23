import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Grade, AverageGrade } from '../../services/grade.service';
import { Student, Subject } from '../../services/teacher.service';
import { StudentService } from '../../services/student.service';
import { GradeService } from '../../services/grade.service';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrl: './grade.component.css',
  standalone: true,
  imports: [CommonModule]
})
export class GradeComponent implements OnInit {
  students: Student[] = [];
  subjects: Subject[] = [];
  grades: Grade[] = [];
  averageGrade?: AverageGrade;
  selectedStudent?: Student | null = null;
  selectedSubject?: Subject | null = null;
  errorMessage: string = '';

  constructor(
    private gradeService: GradeService,
    private studentService: StudentService,
  ) { }

  ngOnInit(): void {
    this.getAllStudents();
  }

  getAllStudents(): void {
    this.studentService.getAllStudents().subscribe({
      next: (students) => {
        console.log('Fetched students:', students);
        this.students = students;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching students:', err);
      }
    });
  }

  selectStudent(student: Student): void {
    this.selectedStudent = student;
    this.subjects = [];
    this.selectedSubject = null;
    this.getSubjectsByStudentCode(student.studentCode);
    this.clearGradesAndAverage();
  }

  getSubjectsByStudentCode(studentCode: string): void {
    this.studentService.getSubjectsByStudentCode(studentCode).subscribe({
      next: (subjects) => {
        console.log('Fetched subjects:', subjects);
        this.subjects = subjects;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching subjects:', err);
      }
    });
  }

  selectSubject(subject: Subject): void {
    this.selectedSubject = subject;
    if (this.selectedStudent) {
      this.getGradesByStudentAndSubject(this.selectedStudent.studentCode, subject.id);
      this.getAverageGradeByStudentAndSubject(this.selectedStudent.studentCode, subject.id);
    }
  }

  getGradesByStudentAndSubject(studentCode: string, subjectId: number): void {
    this.gradeService.getGradesByStudentAndSubject(studentCode, subjectId).subscribe({
      next: (grades) => {
        console.log('Fetched grades:', grades);
        this.grades = grades;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching grades:', err);
      }
    });
  }

  getAverageGradeByStudentAndSubject(studentCode: string, subjectId: number): void {
    this.gradeService.getAverageGradeByStudentAndSubject(studentCode, subjectId).subscribe({
      next: (averageGrade) => {
        console.log('Fetched average grade:', averageGrade);
        this.averageGrade = averageGrade;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching average grade:', err);
      }
    });
  }

  clearGradesAndAverage(): void {
    this.grades = [];
    this.averageGrade = undefined;
  }
}
