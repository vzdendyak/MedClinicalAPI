import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {LoginRequest} from '../../data/models/login-request';
import {AuthService} from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
  }

  //
  // get emailGet(): any {
  //   return this.loginForm.get('email');
  // }
  //
  // get passwordGet(): any {
  //   return this.loginForm.get('password');
  // }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$')]],
      password: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')]]
    });
  }

  loginSubmit() {
    const model: LoginRequest = {email: this.loginForm.get('email').value, password: this.loginForm.get('password').value};
    this.authService.login(model).subscribe(value => {
      console.log(value);
    });
  }
}
