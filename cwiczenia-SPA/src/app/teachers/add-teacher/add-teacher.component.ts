import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Teacher } from 'src/app/models/teacher';
import { TeacherService } from 'src/app/services/teacher.service';
import { ClassService } from 'src/app/services/class.service';
import { SubjectService } from 'src/app/services/subject.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { Class } from 'src/app/models/class';
import { Subjects } from 'src/app/models/subjects';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.css']
})
export class AddTeacherComponent implements OnInit {
  addTeacherForm: FormGroup;

  newTeacher: Teacher;

  classList: Class[];
  subjectList: Subjects[];

  constructor(private teacherService: TeacherService, private classService: ClassService, private subjectService: SubjectService,
                private alertify: AlertifyService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.loadLists();
    this.createForm();
  }

  loadLists() {
    this.classService.getClasses().subscribe((classes: Class[]) => {
      this.classList = classes;
    });
    this.subjectService.getSubjects().subscribe((subjects: Subjects[]) => {
      this.subjectList = subjects;
    });
  }

  createForm() {
    this.addTeacherForm = this.fb.group({
      name: [''],
      photo: [''],
      surname: [''],
      dateOfBirth: [''],
      classId: [],
      subjectId: ['']
    });
  }

  onSubmit() {
    this.newTeacher = Object.assign({}, this.addTeacherForm.value);
    this.teacherService.addTeacher(this.newTeacher).subscribe(() => {
      this.alertify.success('Dodano nauczyciela');
      this.router.navigate(['/nauczyciel']);
    }, error => {
      this.alertify.error(error);
    });
  }

}
