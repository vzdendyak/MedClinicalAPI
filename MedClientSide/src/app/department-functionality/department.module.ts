import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {DepartmentComponent} from './department/department.component';
import {DepartmentsListComponent} from './departments-list/departments-list.component';
import {AppModule} from '../app.module';
import {MaterialModule} from '../material/material.module';


@NgModule({
  declarations: [DepartmentComponent, DepartmentsListComponent],
  imports: [
    CommonModule, MaterialModule
  ]
})
export class DepartmentModule {
}
