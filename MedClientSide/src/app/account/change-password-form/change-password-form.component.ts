import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MatDialogRef} from '@angular/material/dialog';
import {AccountService} from '../services/account.service';
import {ChangePasswordRequest} from '../../data/models/ChangePasswordRequest';

@Component({
  selector: 'app-change-password-form',
  templateUrl: './change-password-form.component.html',
  styleUrls: ['./change-password-form.component.scss']
})
export class ChangePasswordFormComponent implements OnInit {
  pageForm: FormGroup;
  isLoading = false;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<ChangePasswordFormComponent>,
              private accountService: AccountService) {

  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      oldPassword: [null, [Validators.required]],
      newPassword: [null, [Validators.required]]
    });
  }

  close(result: boolean): void {
    this.dialogRef.close({success: result});

  }

  onSubmit(): void {
    const model: ChangePasswordRequest = {
      oldPassword: this.pageForm.get('oldPassword').value,
      newPassword: this.pageForm.get('newPassword').value,
      id: localStorage.getItem('uId')
    };

    this.accountService.changePassword(model).subscribe(value => {
      if (value) {
        this.close(true);
      }
    });
  }

}
