import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Teacher } from '../models/teacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  apiUrl = environment.baseUrl;

constructor(private http: HttpClient) { }

  getTeacher(id: number): Observable<Teacher> {
    return this.http.get<Teacher>(this.apiUrl + 'teachers/' + id);
  }

  getTeachers(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.apiUrl + 'teachers');
  }

  addTeacher(teacher: Teacher) {
    return this.http.post(this.apiUrl + 'teachers', teacher);
  }

  deleteTeacher(id: number) {
    return this.http.delete(this.apiUrl + 'teachers/' + id);
  }

  updateTeacher(id: number, teacher: Teacher) {
    return this.http.put(this.apiUrl + 'teachers/' + id, teacher);
  }

}
