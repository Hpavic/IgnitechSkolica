import { Component, OnInit  } from '@angular/core';
import { Student, Subject, Teacher } from '../../services/teacher.service';
import { StudentService } from '../../services/student.service';
import { SubjectService } from '../../services/subject.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrl: './subject.component.css',
  standalone: true,
  imports: [CommonModule]
})
export class SubjectComponent implements OnInit {
  students: Student[] = [];
  subjects: Subject[] = [];
  selectedStudent?: Student | null = null;
  selectedSubject?: Subject | null = null;
  teacher?: Teacher | null = null;
  errorMessage: string = '';

  constructor(private studentService: StudentService, private subjectService: SubjectService) { }

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
        this.subjects = subjects;
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error fetching subjects:', err);
      }
    });
  }

  selectStudent(student: Student): void {
    console.log('Selected student:', student);
    this.selectedStudent = student;
    this.subjects = [];
    this.selectedSubject = null;
    this.teacher = null;
    this.getSubjectsByStudentCode(student.studentCode);
  }

  selectSubject(subject: Subject): void {
    console.log('Selected subject:', subject);
    this.selectedSubject = subject;
    this.checkAndFetchTeacher();
  }

  checkAndFetchTeacher(): void {
    if (this.selectedStudent && this.selectedSubject) {
      console.log(`Fetching teacher for studentCode: ${this.selectedStudent.studentCode} and subjectId: ${this.selectedSubject.id}`);
      this.subjectService.getTeacherByStudentAndSubject(this.selectedStudent.studentCode, this.selectedSubject.id).subscribe({
        next: (teacher) => {
          console.log('Fetched teacher:', teacher);
          this.teacher = teacher;
        },
        error: (err) => {
          this.errorMessage = err.message;
          console.error('Error fetching teacher:', err);
        }
      });
    }
  }
}
