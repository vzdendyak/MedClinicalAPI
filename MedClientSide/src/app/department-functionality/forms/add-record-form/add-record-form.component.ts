import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {User} from '../../../data/models/user';

@Component({
  selector: 'app-add-record-form',
  templateUrl: './add-record-form.component.html',
  styleUrls: ['./add-record-form.component.scss']
})
export class AddRecordFormComponent implements OnInit {
  pageForm: FormGroup;
  doctors: User[];
  selectedDoctor: User;
  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<AddRecordFormComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData) {
    if (data.doctors) {
      this.doctors = data.doctors;
    }
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      Doctor: [null, [Validators.required]],
      Date: [null, [Validators.required]],
      Hour: [null, [Validators.required]]
    });
  }

  close(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    alert('submit');
  }
}

export interface DialogData {
  doctors: User[];
}
