import {Injectable} from '@angular/core';
import {Environment} from '@angular/compiler-cli/src/ngtsc/typecheck/src/environment';
import {environment} from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AuthResponse} from '../data/models/auth/auth-response';
import {RegistrationRequest} from '../data/models/auth/registration-request';
import {LoginRequest} from '../data/models/auth/login-request';
import {JwtHelperService} from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = environment.apiUrl + '/auth';
  requestOptions: object = {
    withCredentials: true
  };

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
  }

  login(loginModel: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(this.url + '/login', loginModel, this.requestOptions);
  }

  register(registerModel: RegistrationRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(this.url + '/register', registerModel, this.requestOptions);
  }

  logOut(): void {
    this.clearStorage();
  }

  isUserAuthenticated() {
    const token: string = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    } else {
      return false;
    }
  }

  clearStorage(): void {
    localStorage.removeItem('jwt');
    localStorage.removeItem('uId');
    localStorage.removeItem('email');
    localStorage.removeItem('expires');
  }
}
