import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Class } from '../models/class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  baseUrl = environment.baseUrl;

constructor(private http: HttpClient) { }

  getClass(id: number): Observable<Class> {
    return this.http.get<Class>(this.baseUrl + 'classes/' + id);
  }

  getClasses(): Observable<Class[]> {
    return this.http.get<Class[]>(this.baseUrl + 'classes');
  }

  addClass(clas: Class) {
    return this.http.post(this.baseUrl + 'classes', clas);
  }

  updateClass(id: number, clas: Class) {
    return this.http.put(this.baseUrl + 'classes/' + id, clas);
  }

  deleteClass(id: number) {
    return this.http.delete(this.baseUrl + 'classes/' + id);
  }

}
