import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Enrollment } from 'src/app/models/enrollment';
import { StudentService } from 'src/app/services/student.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';
import { SubjectService } from 'src/app/services/subject.service';
import { Subjects } from 'src/app/models/subjects';
import { Student } from 'src/app/models/student';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/public_api';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-add-enrollment',
  templateUrl: './add-enrollment.component.html',
  styleUrls: ['./add-enrollment.component.css']
})
export class AddEnrollmentComponent implements OnInit {
  addGradeForm: FormGroup;

  newEnrollment: Enrollment;

  subjectList: Subjects[];
  studentList: Student[];
  gradeList: number[] = [1, 2, 3, 4, 5, 6];

  constructor(private fb: FormBuilder, private studentService: StudentService, private alertify: AlertifyService, private route: Router,
    private subjectService: SubjectService) { }

  ngOnInit() {
    this.loadLists();
    this.createEnrollment();
  }

  createEnrollment() {
    this.addGradeForm = this.fb.group({
      student: [new Student],
      subject: [new Subject],
      grade: []
    });
  }

  get diagnostic() { return JSON.stringify(this.addGradeForm.value); }

  loadLists() {
    this.studentService.getStudents().subscribe((students: Student[]) => {
      this.studentList = students;
    });
    this.subjectService.getSubjects().subscribe((subjects: Subjects[]) => {
      this.subjectList = subjects;
    });
  }

  onSubmit() {
    if (this.addGradeForm.valid) {
      this.newEnrollment = Object.assign({}, this.addGradeForm.value);
      this.newEnrollment.studentId = this.newEnrollment.student.id;
      this.newEnrollment.subjectId = this.newEnrollment.subject.id;
      this.studentService.addEnrollment(this.newEnrollment).subscribe(() => {
        this.alertify.success('Dodano ocene');
        this.route.navigate(['/uczen']);
      }, error => {
        this.alertify.error(error);
      });
      // this.addGradeForm.reset();
    }
    console.log(this.newEnrollment);
  }


}
