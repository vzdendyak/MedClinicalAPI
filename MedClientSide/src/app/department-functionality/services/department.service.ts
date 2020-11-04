import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Department} from '../../data/models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  url: string = environment.apiUrl + '/departments';

  constructor(private http: HttpClient) {
  }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.url);
  }

  getDepartment(id: number): Observable<Department> {
    return this.http.get<Department>(this.url + `/${id}`);
  }
}
