import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {User} from '../../data/models/user';
import {ChangePasswordRequest} from '../../data/models/ChangePasswordRequest';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  url: string = environment.apiUrl + '/users';

  constructor(private http: HttpClient) {
  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${this.url}/${id}`);
  }

  updateUser(user: User): Observable<boolean> {
    return this.http.put<boolean>(this.url, user);
  }

  changePassword(model: ChangePasswordRequest): Observable<boolean> {
    return this.http.put<boolean>(`${this.url}/password`, model);
  }
}
