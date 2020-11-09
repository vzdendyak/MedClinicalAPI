import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DepartmentService} from '../services/department.service';
import {Department} from '../../data/models/department';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordFormComponent} from '../forms/add-record-form/add-record-form.component';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {

  departmentId: number;
  department: Department;

  constructor(private route: ActivatedRoute, private departmentService: DepartmentService,
              public dialog: MatDialog
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
      data: {   doctors: this.department.doctors}
    });
    dialogRef.afterClosed().subscribe((value) => {
      console.log('dialog closed');
    });
  }

}
