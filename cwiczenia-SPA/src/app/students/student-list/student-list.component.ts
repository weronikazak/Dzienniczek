import { Component, OnInit, PipeTransform, Output, EventEmitter, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { DecimalPipe } from '@angular/common';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';
import { ListFilterPipe } from 'src/app/pipes/list-filter.pipe';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})


export class StudentListComponent implements OnInit {
  students: Student[];
  @Input() searchModel: Student;

  ngOnInit() {
    this.loadStudents();
  }

  constructor(private studentService: StudentService, public listFilter: ListFilterPipe) { }

  loadStudents() {
    this.studentService.getStudents().subscribe((students: Student[]) => {
      this.students = students;
    });
  }
}
