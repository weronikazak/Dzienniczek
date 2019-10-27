import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ClassService } from 'src/app/services/class.service';
import { TeacherService } from 'src/app/services/teacher.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Class } from 'src/app/models/class';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/models/teacher';

@Component({
  selector: 'app-add-class',
  templateUrl: './add-class.component.html',
  styleUrls: ['./add-class.component.css']
})
export class AddClassComponent implements OnInit {
  addClassForm: FormGroup;
  newClass: Class;

  teacherList: Teacher[];

  constructor(private alertify: AlertifyService, private classService: ClassService,
    private teacherService: TeacherService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.loadTeachers();
    this.createForm();
  }

  createForm() {
    this.addClassForm = this.fb.group({
      className: [''],
      year: [Date.now],
      teacherId: ['']
    });
  }

  loadTeachers() {
    this.teacherService.getTeachers().subscribe((teachers: Teacher[]) => {
      this.teacherList = teachers;
    });
  }

  onSubmit() {
    this.newClass = Object.assign({}, this.addClassForm.value);
    this.classService.addClass(this.newClass).subscribe(() => {
      this.alertify.success('Dodano nową klasę.');
      this.router.navigate(['/klasa']);
    }, error => {
      this.alertify.error(error);
    });

  }

}
