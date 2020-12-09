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
  photoPath: string;
  depPhotoParh: string;
  public response: { dbPath: '' };
  timeStamp: number;

  constructor(private fb: FormBuilder,
              private accountService: AccountService) {
    const uId = localStorage.getItem('uId');
    this.accountService.getUser(uId).subscribe(value => {

      this.user = value;
      this.photoPath = `https://localhost:5001/api/account/avatar/${this.user.id}`;
      this.depPhotoParh = `https://localhost:5001/api/departments/image/${this.user.departmentId}`;
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

  public getLinkPicture() {
    if (this.timeStamp) {
      return this.photoPath + '?' + this.timeStamp;
    }
    return this.photoPath;
  }

  public getDepartmentLinkPicture() {
    if (this.timeStamp) {
      return this.photoPath + '?' + this.timeStamp;
    }
    return this.depPhotoParh;
  }

  public setLinkPicture(url: string) {
    this.photoPath = url;
    this.timeStamp = (new Date()).getTime();
  }

  public uploadFinished = (event) => {
    this.setLinkPicture(this.photoPath);
  };


}
