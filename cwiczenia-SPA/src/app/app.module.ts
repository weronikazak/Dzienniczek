import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { StudentDetailComponent } from './students/student-detail/student-detail.component';
import { StudentListComponent } from './students/student-list/student-list.component';
import { TeacherListComponent } from './teachers/teacher-list/teacher-list.component';
import { HomeComponent } from './home/home/home.component';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { routes } from 'src/routes';
import { StudentAddComponent } from './students/student-add/student-add.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DecimalPipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DesktopComponent } from './home/desktop/desktop.component';
import { StudentService } from './services/student.service';
import { AlertifyService } from './services/alertify.service';


@NgModule({
   declarations: [
      AppComponent,
      StudentDetailComponent,
      StudentListComponent,
      TeacherListComponent,
      HomeComponent,
      NavbarComponent,
      StudentAddComponent,
      DesktopComponent
   ],
   imports: [
      BrowserModule,
      NgbModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(routes),
      HttpClientModule
   ],
   providers: [
      DecimalPipe,
      StudentService,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
