import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AdminService} from '../../services/admin.service';
import {DialogData} from '../create-user-form/create-user-form.component';
import {Department} from '../../../data/models/department';
import {Schedule} from '../../../data/models/schedule';
import {Address} from '../../../data/models/address';
import {HttpClient, HttpEventType, HttpSentEvent} from '@angular/common/http';
import {log} from 'util';

@Component({
  selector: 'app-create-department-form',
  templateUrl: './create-department-form.component.html',
  styleUrls: ['./create-department-form.component.scss']
})
export class CreateDepartmentFormComponent implements OnInit {
  pageForm: FormGroup;
  addresses: Address[];
  selAddress: Address;
  filename: string;
  schedules: Schedule[];
  selSchedule: Schedule;

  formData: FormData;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<CreateDepartmentFormComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private adminService: AdminService,
              private http: HttpClient) {
    this.adminService.getDepartmentFormData().subscribe(value => {
      this.addresses = value.addresses;
      this.schedules = value.schedules;
    });
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      name: [null, [Validators.required]],
      description: [null, [Validators.required]],
      photoPath: [null]
    });
  }

  onSubmit() {
    // @ts-ignore
    const model: Department = {
      id: 0,
      departmentName: this.pageForm.get('name').value,
      description: this.pageForm.get('description').value,
      addressId: this.selAddress.id,
      scheduleId: this.selSchedule.id,
      isVisible: null,
      doctors: null,
      departmentServices: null,
      schedule: null
    };
    this.adminService.createDepartment(model).subscribe(value => {
      console.log(value);
      if (value && this.formData) {
        this.formData.append('department', value.toString());
        this.http.post('https://localhost:5001/api/departments/avatar', this.formData, {reportProgress: true, observe: 'events'})
          .subscribe(event => {
            if (event.type === HttpEventType.UploadProgress) {
            } else if (event.type === HttpEventType.Response) {
              console.log('uploaded');
            }
          });
        this.dialogRef.close(true);
      }
    });
    console.log(model);
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    const fileToUpload = files[0] as File;
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.formData = formData;
    this.filename = fileToUpload.name;
  };

  close(b: boolean) {
    this.dialogRef.close(true);
  }
}
