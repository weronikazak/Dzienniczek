import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Student } from '../models/student';
import { StudentService } from '../services/student.service';
import { Observable, of } from 'rxjs';
import { AlertifyService } from '../services/alertify.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class StudentResolver implements Resolve<Student> {
    constructor(private studentService: StudentService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Student> {
        return this.studentService.getStudent(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['/uczen']);
                return of(null);
            })
        );
    }
}
