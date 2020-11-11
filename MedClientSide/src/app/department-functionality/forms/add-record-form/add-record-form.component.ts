import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {User} from '../../../data/models/user';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import {DoctorService} from '../../services/doctor.service';
import {DatePipe, formatDate} from '@angular/common';

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
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private doctorService: DoctorService) {
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

  addEvent(event: MatDatepickerInputEvent<Date>): void {
    console.log(event);
    const date = event.value;
    const date2 = new DatePipe('en-Us').transform(event.value, 'full', 'GMT+0');
    const epochTicks = 621355968000000000;

    const ticksPerMillisecond = 10000;

    const yourTicks = epochTicks + (date.getTime() * ticksPerMillisecond);
    this.doctorService.getHours('365468ba-020a-4850-82cd-e4b0e703b6f5', yourTicks).subscribe(rec => {
      console.log(rec);
    });
    console.log(date);
    console.log(date2);
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
