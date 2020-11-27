import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AdminService} from '../../services/admin.service';
import {DialogData} from '../create-user-form/create-user-form.component';
import {Department} from '../../../data/models/department';
import {Schedule} from '../../../data/models/schedule';
import {Address} from '../../../data/models/address';

@Component({
  selector: 'app-create-department-form',
  templateUrl: './create-department-form.component.html',
  styleUrls: ['./create-department-form.component.scss']
})
export class CreateDepartmentFormComponent implements OnInit {
  pageForm: FormGroup;
  addresses: Address[];
  selAddress: Address;

  schedules: Schedule[];
  selSchedule: Schedule;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<CreateDepartmentFormComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private adminService: AdminService) {
    this.adminService.getSchedules().subscribe(value => {
      this.schedules = value;
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
      id: null,
      departmentName: this.pageForm.get('name').value,
      description: this.pageForm.get('description').value,
      addressId: this.selAddress.id,
      scheduleId: this.selSchedule.id
    };
    console.log(model);
  }

}
