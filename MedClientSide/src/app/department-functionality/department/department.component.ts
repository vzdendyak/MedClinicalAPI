import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DepartmentService} from '../services/department.service';
import {Department} from '../../data/models/department';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordFormComponent} from '../forms/add-record-form/add-record-form.component';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {
  departmentId: number;
  department: Department;
  isDialogOpen = false;
  isServicesVisible = false;

  constructor(private route: ActivatedRoute, private departmentService: DepartmentService,
              public dialog: MatDialog, private snackBar: MatSnackBar
  ) {
  }

  ngOnInit() {
    console.log('NgOnInit');
    this.route.params.subscribe(params => {
      if (params.id) {
        this.departmentId = params.id;
        this.departmentService.getDepartment(this.departmentId).subscribe(dep => {
          console.log('GOT ' + dep + dep.departmentName);
          this.department = dep;
        });
      }
    });
  }

  addRecordDialogOpen(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddRecordFormComponent, {
      width: '450px',
      data: {doctors: this.department.doctors, depServices: this.department.departmentServices},
      panelClass: 'my-dialog-window'
    });
    dialogRef.afterOpened().subscribe(res => {
      this.isDialogOpen = true;
      console.log('dialog - ' + this.isDialogOpen);
    });
    dialogRef.afterClosed().subscribe((value) => {
      this.isDialogOpen = false;
      console.log('dialog - ' + this.isDialogOpen);
      if (value.success) {
        this.snackBar.open('Запис створено', 'OK', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          panelClass: ['my-snack'],
          politeness: 'assertive'
        });
      }
    });
  }

  hideServices() {
    this.isServicesVisible = !this.isServicesVisible;
  }
}
