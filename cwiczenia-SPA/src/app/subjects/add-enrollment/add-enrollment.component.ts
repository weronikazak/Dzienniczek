import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Enrollment } from 'src/app/models/enrollment';

@Component({
  selector: 'app-add-enrollment',
  templateUrl: './add-enrollment.component.html',
  styleUrls: ['./add-enrollment.component.css']
})
export class AddEnrollmentComponent implements OnInit {
  addGradeForm: FormGroup;
  newEnrollment: Enrollment;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
  }

  createEnrollment() {
    this.addGradeForm = this.fb.group({
      
    });
  }

  onSubmit(enrollment) {
    if (this.addGradeForm.valid) {
      this.newEnrollment = Object.assign({}, enrollment);
      
    }
  }

}
