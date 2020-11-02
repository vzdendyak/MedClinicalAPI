import { DepartmentComponent } from './department/department/department.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from './material/material.module';
import { HeaderComponent } from './navigation/header/header.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { LoginComponent } from './account/login/login.component';
import {LoginModule} from './account/login.module';
import {RegistrationComponent} from './account/registration/registration.component';
import { MainPageComponent } from './department/main-page/main-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    DepartmentComponent,
    MainPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LoginModule,
    RouterModule.forRoot(
      [
        {path: 'account/login', component: LoginComponent},
        {path: 'account/registration', component: RegistrationComponent},
        {path: 'department', component: DepartmentComponent},
        {path: 'main',  component: MainPageComponent}
        ]),
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
