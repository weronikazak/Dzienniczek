import { Component, OnInit, Input } from '@angular/core';
import { Student } from 'src/app/models/student';
import { Router, ActivatedRoute } from '@angular/router';
import { StudentService } from 'src/app/services/student.service';
import { Enrollment } from 'src/app/models/enrollment';

@Component({
  selector: 'app-student-enrollments',
  templateUrl: './student-enrollments.component.html',
  styleUrls: ['./student-enrollments.component.css']
})
export class StudentEnrollmentsComponent implements OnInit {
  student: Student;
  enrollments: Enrollment[];
  @Input() searchModel: Enrollment;

  constructor(private route: ActivatedRoute, private studentService: StudentService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.student = data['student'];
    });

    this.loadEnrollments();
  }

  loadEnrollments() {
    this.studentService.getEnrollments(this.student.id).subscribe((enrollments: Enrollment[]) => {
      this.enrollments = enrollments;
    });
  }

}
