import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MatDialogRef} from '@angular/material/dialog';
import {AdminService} from '../../services/admin.service';
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

    });
    this.dialogRef.close(true);

  }

}
