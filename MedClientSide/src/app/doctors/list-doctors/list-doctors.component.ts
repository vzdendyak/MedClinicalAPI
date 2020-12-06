import {Component, OnInit} from '@angular/core';
import {DepartmentService} from '../../department-functionality/services/department.service';
import {Department} from '../../data/models/department';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordFormComponent} from '../../department-functionality/forms/add-record-form/add-record-form.component';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-list-doctors',
  templateUrl: './list-doctors.component.html',
  styleUrls: ['./list-doctors.component.scss']
})
export class ListDoctorsComponent implements OnInit {
  showDoctors: boolean;
  departments: Department[];
  isDialogOpen = false;

  constructor(private departmentService: DepartmentService, public dialog: MatDialog, private snackBar: MatSnackBar) {
    this.departmentService.getDepartments().subscribe(value => {
      this.departments = value;
      console.log(this.departments);
    });
  }

  ngOnInit(): void {
  }

  TitleMed(): void {
    let doctorsBlock = document.getElementById('doctors_block');
    let arrow = document.getElementById('arrow');
    if (doctorsBlock.style.height === '0px') {
      doctorsBlock.style.height = '500px';
      arrow.style.transform = 'rotate(90deg)';
    } else {
      doctorsBlock.style.height = '0px';
      arrow.style.transform = 'rotate(0deg)';
    }
    console.log(doctorsBlock);
  }

  toogleBlock(dep: Department) {
    console.log('debug');
    var depp = this.departments.find(dp => dp.id == dep.id);
    depp.isVisible = !depp.isVisible;
  }

  openDialog(dep: Department) {
    let dialogRef;
    dialogRef = this.dialog.open(AddRecordFormComponent, {
      width: '450px',
      data: {doctors: dep.doctors, depServices: dep.departmentServices, name: dep.departmentName},
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

  public getLinkPicture(id: string) {
   return `https://localhost:5001/api/account/avatar/${id}`;
  }
}