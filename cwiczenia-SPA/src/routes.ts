import { Routes } from '@angular/router';
import { HomeComponent } from './app/home/home/home.component';
import { StudentListComponent } from './app/students/student-list/student-list.component';
import { TeacherListComponent } from './app/teachers/teacher-list/teacher-list.component';
import { StudentAddComponent } from './app/students/student-add/student-add.component';
import { ClassListComponent } from './app/class/class-list/class-list.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'uczen', component: StudentListComponent},
  { path: 'nauczyciel', component: TeacherListComponent},
  { path: 'klasa', component: ClassListComponent},
  { path: 'przedmioty', component: HomeComponent},
  { path: 'uczen/dodaj', component: StudentAddComponent},
];
