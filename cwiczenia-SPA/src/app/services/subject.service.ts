import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Subjects } from '../models/subjects';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

constructor(private http: HttpClient) { }
  apiUrl = environment.baseUrl;

  getSubject(id: number): Observable<Subjects> {
      return this.http.get<Subjects>(this.apiUrl + 'subjects/' + id);
  }

  getSubjects(): Observable<Subjects[]> {
    return this.http.get<Subjects[]>(this.apiUrl + 'subjects');
  }

  addSubject(subject: Subjects) {
    return this.http.post(this.apiUrl + 'subjects', subject);
  }

  deleteSubject(id: number) {
    return this.http.delete(this.apiUrl + 'subjects/' + id);
  }
}
