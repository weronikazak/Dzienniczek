import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  baseUrl = environment.baseUrl;

constructor(private http: HttpClient) { }


  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseUrl + 'students');
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.baseUrl + 'students/' + id);
  }

  addStudent(newStudent: Student) {
    return this.http.post(this.baseUrl + 'students', newStudent);
  }

  updateStudent(id: number, student: Student) {
    return this.http.put<Student>(this.baseUrl + 'students/' + id, student);
  }

  deleteStudent(id: number) {
    return this.http.delete<Student>(this.baseUrl + 'students/' + id);
  }
}
