import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../auth.service';
import {LoginRequest} from '../../data/models/auth/login-request';
import {Router} from '@angular/router';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private jwtHelper: JwtHelperService) {
  }

  ngOnInit(): void {
    this.authService.clearStorage();
    this.initForm();
  }

  private initForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$')]],
      password: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')]]
    });
  }

  loginSubmit(): void {
    const model: LoginRequest = {email: this.loginForm.get('email').value, password: this.loginForm.get('password').value};
    this.authService.login(model).subscribe(value => {
      const token = value.token;
      if (token) {
        const decodedInfo = this.jwtHelper.decodeToken(token);
        localStorage.setItem('jwt', token);
        localStorage.setItem('uId', decodedInfo.id);
        localStorage.setItem('email', decodedInfo.email);
        localStorage.setItem('expires', decodedInfo.expires);
      }
      this.router.navigateByUrl('/');
    }, error => {
      console.log(error);
    });
  }
}
