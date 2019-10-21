import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { SubjectService } from 'src/app/services/subject.service';
import { Subjects } from 'src/app/models/subjects';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subject-add',
  templateUrl: './subject-add.component.html',
  styleUrls: ['./subject-add.component.css']
})
export class SubjectAddComponent implements OnInit {
  addSubjectForm: FormGroup;
  newSubject: Subjects;

  constructor(private fb: FormBuilder, private subjectService: SubjectService,
    private alertify: AlertifyService, private router: Router) { }

  createForm() {
    this.addSubjectForm = this.fb.group({
      subjectName: [''],
      teacher: ['renata']
    });
  }

  ngOnInit() {
    this.createForm();
  }

  onSubmit() {
    if (this.addSubjectForm.valid) {
      this.newSubject = Object.assign({}, this.addSubjectForm.value);
      this.subjectService.addSubject(this.newSubject).subscribe(() => {
        this.alertify.success('Pomyślnie dodano przedmiot');
        this.router.navigate(['/przedmiot']);
      }, error => {
        this.alertify.error(error);
      });
      this.addSubjectForm.reset();
    }
  }

}
