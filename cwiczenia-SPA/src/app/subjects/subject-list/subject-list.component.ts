import { Component, OnInit } from '@angular/core';
import { Subjects } from 'src/app/models/subjects';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {
  subjects: Subjects[];

  constructor(private subjectService: SubjectService) { }

  ngOnInit() {
    this.loadSubjects();
  }

  loadSubjects() {
    this.subjectService.getSubjects().subscribe((subjects: Subjects[]) => {
      this.subjects = subjects;
    });
  }

}
