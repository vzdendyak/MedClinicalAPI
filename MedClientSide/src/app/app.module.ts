import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';


import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from './material/material.module';
import {HeaderComponent} from './navigation/header/header.component';
import {FooterComponent} from './navigation/footer/footer.component';

import {MainPageComponent} from './main-page/main-page.component';
import {DepartmentComponent} from './department-functionality/department/department.component';
import {DepartmentsListComponent} from './department-functionality/departments-list/departments-list.component';
import {DepartmentModule} from './department-functionality/department.module';
import { CabinetComponent } from './account/cabinet/cabinet.component';
import {LoginModule} from './auth/login.module';
import {LoginComponent} from './auth/login/login.component';
import {RegistrationComponent} from './auth/registration/registration.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    CabinetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LoginModule,
    RouterModule.forRoot(
      [
        {path: 'auth/login', component: LoginComponent},
        {path: 'auth/registration', component: RegistrationComponent},
        {path: 'account/cabinet', component: CabinetComponent},
        {path: 'departments', component: DepartmentsListComponent},
        {path: 'department/:id', component: DepartmentComponent},
        {path: 'main', component: MainPageComponent},
        {path: '**', redirectTo: 'main'}

      ]),
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DepartmentModule
  ],
  providers: [],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
