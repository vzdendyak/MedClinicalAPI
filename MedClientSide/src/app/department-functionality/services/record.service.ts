import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Record} from '../../data/models/record';

@Injectable({
  providedIn: 'root'
})
export class RecordService {
  url: string = environment.apiUrl + '/records';


  constructor(private http: HttpClient) {
  }

  addRecord(record: Record): Observable<boolean> {
    return this.http.post<boolean>(this.url, record);
  }

}
