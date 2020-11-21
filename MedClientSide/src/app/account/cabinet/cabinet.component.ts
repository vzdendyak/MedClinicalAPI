import {Component, OnInit} from '@angular/core';
import {AccountService} from '../services/account.service';
import {User} from '../../data/models/user';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-cabinet',
  templateUrl: './cabinet.component.html',
  styleUrls: ['./cabinet.component.scss']
})
export class CabinetComponent implements OnInit {
  user: User;
  pageForm: FormGroup;

  constructor(private fb: FormBuilder,
              private accountService: AccountService) {
    const uId = localStorage.getItem('uId');
    this.accountService.getUser(uId).subscribe(value => {
      console.log('user got');
      this.user = value;
    });
  }

  ngOnInit(): void {
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      oldPassword: [null, [Validators.required]],
      newPassword: [null, [Validators.required]]
    });
  }

}
