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
import { NgbModule, NgbDropdown } from '@ng-bootstrap/ng-bootstrap';
import { DecimalPipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DesktopComponent } from './home/desktop/desktop.component';
import { StudentService } from './services/student.service';
import { AlertifyService } from './services/alertify.service';
import { ListFilterPipe } from './pipes/list-filter.pipe';
import { ClassListComponent } from './class/class-list/class-list.component';
import { ClassService } from './services/class.service';
import { TeacherService } from './services/teacher.service';
import { SubjectService } from './services/subject.service';
import { SubjectListComponent } from './subjects/subject-list/subject-list.component';
import { StudentEnrollmentsComponent } from './students/student-enrollments/student-enrollments.component';
import { StudentResolver } from './resolvers/student.resolver';
import { AddEnrollmentComponent } from './subjects/add-enrollment/add-enrollment.component';
import { EnrollmentResolver } from './resolvers/enrollment.resolver';
import { SubjectAddComponent } from './subjects/subject-add/subject-add.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import {MatAutocompleteModule} from '@angular/material/autocomplete';


@NgModule({
   declarations: [
      AppComponent,
      StudentDetailComponent,
      StudentListComponent,
      TeacherListComponent,
      HomeComponent,
      NavbarComponent,
      StudentAddComponent,
      DesktopComponent,
      ListFilterPipe,
      ClassListComponent,
      SubjectListComponent,
      StudentEnrollmentsComponent,
      AddEnrollmentComponent,
      SubjectAddComponent,
   ],
   imports: [
      BrowserModule,
      NgbModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(routes),
      HttpClientModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule,
      TypeaheadModule.forRoot(),
      MatAutocompleteModule
   ],
   providers: [
      StudentService,
      AlertifyService,
      ListFilterPipe,
      TeacherService,
      ClassService,
      SubjectService,
      StudentResolver,
      EnrollmentResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
