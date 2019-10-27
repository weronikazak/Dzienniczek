import { Routes } from '@angular/router';
import { HomeComponent } from './app/home/home/home.component';
import { StudentListComponent } from './app/students/student-list/student-list.component';
import { TeacherListComponent } from './app/teachers/teacher-list/teacher-list.component';
import { StudentAddComponent } from './app/students/student-add/student-add.component';
import { ClassListComponent } from './app/class/class-list/class-list.component';
import { SubjectListComponent } from './app/subjects/subject-list/subject-list.component';
import { StudentEnrollmentsComponent } from './app/students/student-enrollments/student-enrollments.component';
import { StudentResolver } from './app/resolvers/student.resolver';
import { AddEnrollmentComponent } from './app/subjects/add-enrollment/add-enrollment.component';
import { EnrollmentResolver } from './app/resolvers/enrollment.resolver';
import { SubjectAddComponent } from './app/subjects/subject-add/subject-add.component';
import { AddTeacherComponent } from './app/teachers/add-teacher/add-teacher.component';
import { AddClassComponent } from './app/class/add-class/add-class.component';
import { ClassStudentsComponent } from './app/class/class-students/class-students.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'uczen', component: StudentListComponent},
  { path: 'uczen/dodaj', component: StudentAddComponent},
  { path: 'ocena/:id', component: StudentEnrollmentsComponent, resolve: { student: StudentResolver}},
  { path: 'ocena/uczen/:id', component: AddEnrollmentComponent, resolve: { student: EnrollmentResolver}},
  { path: 'nauczyciel', component: TeacherListComponent},
  { path: 'nauczyciel/dodaj', component: AddTeacherComponent},
  { path: 'klasa', component: ClassListComponent},
  { path: 'klasa/dodaj', component: AddClassComponent},
  { path: 'klasa/:id', component: ClassStudentsComponent},
  { path: 'przedmiot', component: SubjectListComponent},
  { path: 'przedmiot/dodaj', component: SubjectAddComponent},
  { path: '**', component: HomeComponent },
];

