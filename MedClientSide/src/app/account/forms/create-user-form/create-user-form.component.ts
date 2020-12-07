import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {User} from '../../../data/models/user';
import {Department} from '../../../data/models/department';
import {AdminService} from '../../services/admin.service';

@Component({
  selector: 'app-create-user-form',
  templateUrl: './create-user-form.component.html',
  styleUrls: ['./create-user-form.component.scss']
})
export class CreateUserFormComponent implements OnInit {
  pageForm: FormGroup;
  roles: string[] = ['Admin', 'Doctor', 'Patient'];
  selectedRole: string;
  departments: Department[];
  selectedDep: Department;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<CreateUserFormComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private adminService: AdminService) {
    this.departments = this.data.departments;
    this.selectedRole = this.roles[1];
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      email: [null, [Validators.required, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$')]],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      age: [null, [Validators.required]],
      userName: [null, [Validators.required]],
      phoneNumber: [null]
    });
    // this.pageForm.disable();
  }

  onSubmit(): void {
    const model: User = {
      email: this.pageForm.get('email').value,
      firstName: this.pageForm.get('firstName').value,
      lastName: this.pageForm.get('lastName').value,
      age: this.pageForm.get('age').value,
      userName: this.pageForm.get('userName').value,
      phoneNumber: this.pageForm.get('phoneNumber').value,
      id: null,
      departmentId: null,
      department: null,
      records: null,
      role: this.selectedRole
    };
    this.selectedDep && this.selectedRole == 'Doctor' ? model.departmentId = this.selectedDep.id : model.department = null;

    this.adminService.createUser(model).subscribe(value => {

    });
  }

  close(state: boolean): void {
    this.dialogRef.close(state);
  }
}

export interface DialogData {
  departments: Department[];
}
