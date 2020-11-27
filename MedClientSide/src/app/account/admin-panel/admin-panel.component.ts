import {Component, OnInit} from '@angular/core';
import {Department} from '../../data/models/department';
import {User} from '../../data/models/user';
import {Service} from '../../data/models/service';
import {DepartmentService} from '../../department-functionality/services/department.service';
import {AccountService} from '../services/account.service';
import {AdminService} from '../services/admin.service';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordFormComponent} from '../../department-functionality/forms/add-record-form/add-record-form.component';
import {CreateUserFormComponent} from '../forms/create-user-form/create-user-form.component';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  tabLoadTimes: Date[] = [];
  departments: Department[];
  users: User[];
  services: Service[];
  depTableColumns: string[] = ['id', 'depName', 'edit'];
  userTableColumns: string[] = ['id', 'firstName', 'lastName', 'userName', 'email', 'phone', 'age', 'role', 'edit'];
  serviceTableColumns: string[] = ['id', 'name', 'price', 'edit'];

  constructor(private adminService: AdminService, public dialog: MatDialog, private snackBar: MatSnackBar) {
    this.loadDepartments();
    this.loadServices();
    this.loadUsers();

  }

  ngOnInit(): void {
  }

  loadDepartments() {
    this.adminService.getDepartments().subscribe(value => {
      this.departments = value;
    });
  }

  loadUsers() {
    this.adminService.getUsers().subscribe(value => {
      this.users = value;
    });
  }

  loadServices() {
    this.adminService.getServices().subscribe(value => {
      this.services = value;
    });
  }

  addUserFormOpen() {
    let dialogRef;
    dialogRef = this.dialog.open(CreateUserFormComponent, {
      width: '450px',
      data: {departments: this.departments},
      panelClass: 'my-dialog-window'
    });
    dialogRef.afterClosed().subscribe((value) => {
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

  refreshTable(id: number) {
    switch (id) {
      case 1:
        this.loadDepartments();
        break;
      case 2:
        this.loadUsers();
        break;
      case 3:
        this.loadServices();
        break;
    }
  }

  deleteItem(tableId: number, itemId: number) {
    switch (tableId) {
      case 1:
        console.log('dep delete...' + itemId);
        this.adminService.deleteDepartment(itemId).subscribe(value => {
          console.log(value);
        });
        break;
      case 2:
        console.log('user delete...' + itemId);

        this.adminService.deleteUser(itemId.toString()).subscribe(value => {
          console.log(value);
        });
        break;
      case 3:
        console.log('service delete...' + itemId);

        this.adminService.deleteService(itemId).subscribe(value => {
          console.log(value);
        });
        break;
    }
  }

}