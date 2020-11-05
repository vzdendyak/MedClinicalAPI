import {Injectable} from '@angular/core';
import {Environment} from '@angular/compiler-cli/src/ngtsc/typecheck/src/environment';
import {environment} from '../../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {LoginRequest} from '../../data/models/login-request';
import {AuthResponse} from '../../data/models/auth/auth-response';
import {RegistrationRequest} from '../../data/models/registration-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = environment.apiUrl + '/auth';
  requestOptions: object = {
    withCredentials: true
  };

  constructor(private http: HttpClient) {
  }

  login(loginModel: LoginRequest) {
    return this.http.post<AuthResponse>(this.url + '/login', loginModel, this.requestOptions);
  }

  register(registerModel: RegistrationRequest) {
    return this.http.post(this.url + '/register', registerModel, this.requestOptions);
  }
}
