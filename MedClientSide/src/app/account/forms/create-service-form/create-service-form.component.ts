import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {DialogData} from '../create-user-form/create-user-form.component';
import {AdminService} from '../../services/admin.service';
import {HttpClient} from '@angular/common/http';
import {Service} from '../../../data/models/service';

@Component({
  selector: 'app-create-service-form',
  templateUrl: './create-service-form.component.html',
  styleUrls: ['./create-service-form.component.scss']
})
export class CreateServiceFormComponent implements OnInit {
  pageForm: FormGroup;

  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<CreateServiceFormComponent>,
              private adminService: AdminService) {

  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.pageForm = this.fb.group({
      name: [null, [Validators.required]],
      price: [null, [Validators.required]],
      description: [null, [Validators.required]]
    });
  }

  onClose(b: boolean) {
    this.dialogRef.close(b);
  }

  onSubmit() {
    const model: Service = {
      id: 0,
      name: this.pageForm.get('name').value,
      price: this.pageForm.get('price').value,
      description: this.pageForm.get('description').value
    };
    this.adminService.createService(model).subscribe(value => {
      console.log(value);
    });
    this.dialogRef.close(true);

  }

}
