import { Component, OnInit, Input } from '@angular/core';
import { Teacher } from 'src/app/models/teacher';
import { TeacherService } from 'src/app/services/teacher.service';
import { TeacherSubjects } from 'src/app/models/teacherSubjects';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent implements OnInit {
  teachers: TeacherSubjects[];
  // @Input() searchModel: Teacher;

  constructor(private teacherService: TeacherService) { }

  ngOnInit() {
    this.loadTeachers();
  }

  loadTeachers() {
    this.teacherService.getTeacherSubjects().subscribe((teachers: TeacherSubjects[]) => {
      this.teachers = teachers;
    });
  }

}
