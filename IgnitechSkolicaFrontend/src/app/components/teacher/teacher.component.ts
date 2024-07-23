import { Component, OnInit } from '@angular/core';
import { TeacherService, Teacher, Student, Subject } from '../../services/teacher.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TeacherComponent implements OnInit {
  teachers: Teacher[] = [];
  selectedTeacher?: Teacher | null = null;
  students: Student[] = [];
  subjects: Subject[] = [];
  errorMessage: string = '';

  constructor(private teacherService: TeacherService) { }

  ngOnInit(): void {
    this.getAllTeachers();
  }

  getAllTeachers(): void {
    this.teacherService.getAllTeachers().subscribe({
      next: (teachers) => {
        console.log('Fetched teachers:', teachers);
        this.teachers = teachers;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching teachers:', err);
      }
    });
  }

  getStudentsByTeacherCode(teacherCode: string): void {
    this.teacherService.getStudentsByTeacherCode(teacherCode).subscribe({
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

  getSubjectsByTeacherCode(teacherCode: string): void {
    this.teacherService.getSubjectsByTeacherCode(teacherCode).subscribe({
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

  selectTeacher(teacher: Teacher): void {
    this.selectedTeacher = teacher;
    this.getStudentsByTeacherCode(teacher.teacherCode);
    this.getSubjectsByTeacherCode(teacher.teacherCode);
  }
}