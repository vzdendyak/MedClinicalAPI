import {Component, OnInit} from '@angular/core';
import {Department} from '../../data/models/department';
import {User} from '../../data/models/user';
import {Service} from '../../data/models/service';
import {AdminService} from '../services/admin.service';
import {MatDialog} from '@angular/material/dialog';
import {CreateUserFormComponent} from '../forms/create-user-form/create-user-form.component';
import {MatSnackBar} from '@angular/material/snack-bar';
import {CreateDepartmentFormComponent} from '../forms/create-department-form/create-department-form.component';
import {CreateServiceFormComponent} from '../forms/create-service-form/create-service-form.component';

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
  needsUpdate: boolean[] = [false, false, false];
  refresh;
  isLoading = false;

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
      this.clearButton(0);
    });
  }

  loadUsers() {
    this.adminService.getUsers().subscribe(value => {
      this.users = value;
      this.clearButton(1);
    });
  }

  loadServices() {
    this.adminService.getServices().subscribe(value => {
      this.services = value;
      this.clearButton(2);
    });
  }

  addDepartmentFormOpen() {
    let dialogRef;
    dialogRef = this.dialog.open(CreateDepartmentFormComponent, {
      width: '450px',
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
      this.dirtyButton(0);
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
        this.snackBar.open('Користувача створено зі стандартним паролем User-1111', 'OK', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          panelClass: ['my-snack'],
          politeness: 'assertive'
        });
      }
      this.dirtyButton(1);

    });
  }

  addServiceFormOpen() {
    let dialogRef;
    dialogRef = this.dialog.open(CreateServiceFormComponent, {
      width: '450px',
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
      this.dirtyButton(2);

    });
  }

  refreshTable(id: number) {
    this.isLoading = true;
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
    this.isLoading = true;
    switch (tableId) {
      case 1:
        this.adminService.deleteDepartment(itemId).subscribe(value => {
          this.dirtyButton(0);
        });
        break;
      case 2:

        this.adminService.deleteUser(itemId.toString()).subscribe(value => {
          this.dirtyButton(1);
        });
        break;
      case 3:
        this.adminService.deleteService(itemId).subscribe(value => {
          this.dirtyButton(2);
        });
        break;
    }
  }

  dirtyButton(id: number) {
    this.isLoading = false;
    this.refresh = setInterval(() => {
      this.needsUpdate[id] = !this.needsUpdate[id];
    }, 800);
  }

  clearButton(id: number) {
    clearInterval(this.refresh);
    this.needsUpdate[0] = false;
    this.isLoading = false;

  }

}
