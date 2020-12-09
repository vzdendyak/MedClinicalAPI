import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DepartmentService} from '../services/department.service';
import {Department} from '../../data/models/department';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordFormComponent} from '../forms/add-record-form/add-record-form.component';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../auth/auth.service';

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
  saturdayShedule: string;

  constructor(private route: ActivatedRoute, private departmentService: DepartmentService,
              public dialog: MatDialog, private snackBar: MatSnackBar, public authService: AuthService
  ) {
  }

  ngOnInit() {
    ('NgOnInit');
    this.route.params.subscribe(params => {
      if (params.id) {
        this.departmentId = params.id;
        this.departmentService.getDepartment(this.departmentId).subscribe(dep => {
          ('GOT ' + dep + dep.departmentName);
          this.department = dep;
          this.getSchedule();

        });
      }
    });
  }

  addRecordDialogOpen(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddRecordFormComponent, {
      width: '450px',
      data: {doctors: this.department.doctors, depServices: this.department.departmentServices, name: this.department.departmentName},
      panelClass: 'my-dialog-window'
    });
    dialogRef.afterOpened().subscribe(res => {
      this.isDialogOpen = true;

    });
    dialogRef.afterClosed().subscribe((value) => {
      this.isDialogOpen = false;

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

  getSchedule() {
    if (this.department.schedule.isSaturdayWork) {
      this.saturdayShedule = this.department.schedule.startHour.toString() + ':00 - '
        + (this.department.schedule.endHour - 2).toString() + ':00';
    } else {
      this.saturdayShedule = 'Вихідний';
    }
  }

  public getLinkPicture() {
    return `https://localhost:5001/api/departments/image/${this.departmentId}`;
  }

}
