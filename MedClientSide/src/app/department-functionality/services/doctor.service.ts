import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {Department} from '../../data/models/department';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  url: string = environment.apiUrl + '/doctors';


  constructor(private http: HttpClient) {
  }

  getHours(id: string, date: number): Observable<Date[]> {
    return this.http.get<Date[]>(`${this.url}/${id}/${date}`);
  }

}
