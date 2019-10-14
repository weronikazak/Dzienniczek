import { Component, OnInit, PipeTransform } from '@angular/core';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { DecimalPipe } from '@angular/common';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})


export class StudentListComponent implements OnInit {

  students: Student[];

  filter = new FormControl('');

  ngOnInit() {
    this.loadStudents();
  }

  constructor(pipe: DecimalPipe, private studentService: StudentService) { }

  loadStudents() {
    this.studentService.getStudents().subscribe((students: Student[]) => {
      this.students = students;
    });
  }

  search(text: string, pipe: PipeTransform): Student[] {
    return this.students.filter(studednt => {
      const term = text.toLowerCase();
      return studednt.name.toLowerCase().includes(term)
          || pipe.transform(studednt.name).includes(term)
          || pipe.transform(studednt.surname).includes(term);
    });
  }
}
