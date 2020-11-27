import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Department} from '../../data/models/department';
import {Service} from '../../data/models/service';
import {User} from '../../data/models/user';
import {Address} from '../../data/models/address';
import {Schedule} from '../../data/models/schedule';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  url: string = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getAddresses(): Observable<Address[]> {
    return this.http.get<Address[]>(`${this.url}/addresses`);
  }

  getSchedules(): Observable<Schedule[]> {
    return this.http.get<Schedule[]>(`${this.url}/schedules`);
  }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.url}/departments`);
  }

  createDepartment(dep: Department) {
    return this.http.post(`${this.url}/departments`, dep);
  }

  deleteDepartment(id: number) {
    return this.http.delete(`${this.url}/departments/${id}`);
  }


  getServices(): Observable<Service[]> {
    return this.http.get<Service[]>(`${this.url}/services`);
  }

  createService(service: Service) {
    return this.http.post(`${this.url}/services`, service);
  }

  deleteService(id: number) {
    return this.http.delete(`${this.url}/services/${id}`);
  }

  createUser(user: User) {
    return this.http.post(`${this.url}/users`, user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.url}/users`);
  }

  deleteUser(id: string) {
    return this.http.delete(`${this.url}/users/${id}`);
  }
}
