import { Component, OnInit, Input } from '@angular/core';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';
import { ClassService } from 'src/app/services/class.service';
import { ListFilterPipe } from 'src/app/pipes/list-filter.pipe';

@Component({
  selector: 'app-class-students',
  templateUrl: './class-students.component.html',
  styleUrls: ['./class-students.component.css']
})
export class ClassStudentsComponent implements OnInit {
  students: Student[];
  @Input() searchModel: Student;

  ngOnInit() {
    this.loadStudents();
  }

  constructor(private studentService: StudentService, public listFilter: ListFilterPipe, private classService: ClassService) { }

  loadStudents() {
    this.studentService.getStudents().subscribe((students: Student[]) => {
      this.students = students;
    });
  }
}
