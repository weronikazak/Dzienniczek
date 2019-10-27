import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/student';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ClassService } from 'src/app/services/class.service';
import { Class } from 'src/app/models/class';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent implements OnInit {
  addStudentForm: FormGroup;
  newStudent: Student;

  classList: Class[];

  constructor(private studentService: StudentService, private alertify: AlertifyService,
    private fb: FormBuilder, private router: Router, private classService: ClassService) { }

  ngOnInit() {
    this.loadClasses();
    this.createAddStudentForm();
  }

  createAddStudentForm() {
    this.addStudentForm = this.fb.group({
      name: ['Ewelina'],
      surname: ['Nosacz'],
      dateOfBirth: ['1990-09-09'],
      weight: [55],
      height: [160],
      photo: [''],
      classId: ['']
    });
  }

  loadClasses() {
    this.classService.getClasses().subscribe((clases: Class[]) => {
      this.classList = clases;
    });
  }

  onSubmit() {
    if (this.addStudentForm.valid) {
      this.newStudent = Object.assign({}, this.addStudentForm.value);
      this.studentService.addStudent(this.newStudent).subscribe(() => {
        this.alertify.success('Dodano ucznia');
      }, error => {
        console.error(error);
      }, () => {
        this.router.navigate(['/uczen']);
      });
      this.addStudentForm.reset();
    }
  }
}
