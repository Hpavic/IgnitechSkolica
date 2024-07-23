import { Component, OnInit } from '@angular/core';
import { Student, Subject } from '../../services/teacher.service';
import { StudentService } from '../../services/student.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrl: './student.component.css',
  standalone: true,
  imports: [CommonModule]
})
export class StudentComponent implements OnInit {
  students: Student[] = [];
  selectedStudent?: Student | null = null;
  subjects: Subject[] = [];
  errorMessage: string = '';

  constructor(private studentService: StudentService) { }

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

  getSubjectsByStudentCode(studentCode: string): void {
    this.studentService.getSubjectsByStudentCode(studentCode).subscribe({
      next: (subjects) => {
        console.log('Fetched subjects:', subjects);
        this.subjects = subjects
      },
      error: (err) => {
        this.errorMessage = err.message
        console.error('Error fetching subjects:', err);
      }
    });
  }

  selectStudent(student: Student): void {
    this.selectedStudent = student;
    this.getSubjectsByStudentCode(student.studentCode);
  }
}
