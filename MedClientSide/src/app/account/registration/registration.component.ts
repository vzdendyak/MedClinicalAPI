import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {LoginRequest} from '../../data/models/login-request';
import {RegistrationRequest} from '../../data/models/registration-request';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private fb: FormBuilder) {
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
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.pattern('^(?!\\s*$).+')]],
      email: ['', [Validators.required, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$')]],
      password: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')]],
      confirmedPassword: ['', [Validators.required]]
    });
  }

  registrationSubmit() {
    const model: RegistrationRequest = {
      email: this.registerForm.get('email').value,
      password: this.registerForm.get('password').value,
      name: this.registerForm.get('username').value,
      confirmedPassword: this.registerForm.get('confirmedPassword').value
    };  }

}
