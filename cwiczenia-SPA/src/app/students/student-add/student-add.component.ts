import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/student';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent implements OnInit {
  addStudentForm: FormGroup;
  newStudent: Student;

  constructor(private studentService: StudentService, private alertify: AlertifyService,
    private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createAddStudentForm();
  }

  createAddStudentForm() {
    this.addStudentForm = this.fb.group({
      name: ['Ewa XD'],
      surname: [''],
      dateOfBirth: [''],
      weight: [0],
      height: [0],
      photo: ['']
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
      // this.addStudentForm.reset();
    }
  }
}
