import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {User} from '../../../data/models/user';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import {DoctorService} from '../../services/doctor.service';
import {DatePipe, formatDate} from '@angular/common';
import {RecordService} from '../../services/record.service';
import {Record} from '../../../data/models/record';
import {DepartmentService} from '../../../data/models/department-service';
import {Service} from '../../../data/models/service';

@Component({
  selector: 'app-add-record-form',
  templateUrl: './add-record-form.component.html',
  styleUrls: ['./add-record-form.component.scss']
})
export class AddRecordFormComponent implements OnInit {
  pageForm: FormGroup;
  doctors: User[];
  depServices: DepartmentService[];
  selectedService: Service;
  selectedDoctor: User;
  freeHours: Date[];
  selectedHour: Date;
  isLoading = false;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<AddRecordFormComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private doctorService: DoctorService,
              private recordService: RecordService) {
    if (data.doctors) {
      this.doctors = data.doctors;
    }
    if (data.depServices) {
      console.log('got services - ' + data.depServices);
      this.depServices = data.depServices;
    }
    this.freeHours = null;
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      Doctor: [null, [Validators.required]],
      Service: [null, [Validators.required]],
      Date: [null, [Validators.required]],
      Hour: [null, [Validators.required]]
    });
  }

  addEvent(event: MatDatepickerInputEvent<Date>): void {
    console.log(event);
    const date = event.value;
    const yourTicks = 621355968000000000 + (date.getTime() * 10000);

    this.freeHours = null;
    this.isLoading = true;
    this.doctorService.getHours('365468ba-020a-4850-82cd-e4b0e703b6f5', yourTicks).subscribe(rec => {
      console.log(rec);
      this.freeHours = rec;
      this.isLoading = false;
    });
    console.log(date);
  }

  close(result: boolean): void {
    this.dialogRef.close({success: result});
  }

  onSubmit(): void {
    const date = new Date(this.selectedHour);
    const meetingDate = 621355968000000000 + (date.getTime() * 10000);
    const doctorId = this.selectedDoctor.id;
    const patientId = localStorage.getItem('uId');
    const record: Record = {
      id: 0,
      doctorId: this.selectedDoctor.id,
      patientId: localStorage.getItem('uId'),
      dateOfMeeting: meetingDate,
      dateOfRecord: 0,
      serviceId: this.selectedService.id,
      service: null
    };
    this.isLoading = true;
    this.recordService.addRecord(record).subscribe(value => {
      console.log(value);
      this.isLoading = false;
      this.close(true);
    });
  }
}

export interface DialogData {
  doctors: User[];
  depServices: DepartmentService[];
}
