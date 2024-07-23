import { Routes } from '@angular/router';
import { TeacherComponent } from './components/teacher/teacher.component';
import { MainComponent } from './components/main/main.component';
import { GradeComponent } from './components/grade/grade.component';
import { SubjectComponent } from './components/subject/subject.component';
import { StudentComponent } from './components/student/student.component';

export const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'teachers', component: TeacherComponent },
  { path: 'students', component: StudentComponent },
  { path: 'subjects', component: SubjectComponent },
  { path: 'grades', component: GradeComponent }
];