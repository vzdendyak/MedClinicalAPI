import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MaterialModule} from './material/material.module';
import {MainPageComponent} from './main-page/main-page.component';
import {DepartmentComponent} from './department-functionality/department/department.component';
import {DepartmentsListComponent} from './department-functionality/departments-list/departments-list.component';
import {DepartmentModule} from './department-functionality/department.module';
import {CabinetComponent} from './account/cabinet/cabinet.component';
import {LoginModule} from './auth/login.module';
import {LoginComponent} from './auth/login/login.component';
import {RegistrationComponent} from './auth/registration/registration.component';
import {SettingsComponent} from './account/settings/settings.component';
import {MyRecordsComponent} from './account/my-records/my-records.component';
import {SupportComponent} from './account/support/support.component';
import {JwtModule} from '@auth0/angular-jwt';
import {AuthGuard} from './common/guards/auth-guard';
import {AuthInterceptor} from './auth/auth-interceptor';
import {AddRecordFormComponent} from './department-functionality/forms/add-record-form/add-record-form.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MAT_DATE_LOCALE} from '@angular/material/core';
import {AccountModule} from './account/account.module';
import {ChangePasswordFormComponent} from './account/change-password-form/change-password-form.component';
import {ListDoctorsComponent} from './doctors/list-doctors/list-doctors.component';
import {AdminPanelComponent} from './account/admin-panel/admin-panel.component';
import {CreateUserFormComponent} from './account/forms/create-user-form/create-user-form.component';
import {CreateDepartmentFormComponent} from './account/forms/create-department-form/create-department-form.component';
import {CreateServiceFormComponent} from './account/forms/create-service-form/create-service-form.component';
import {AboutComponent} from './About-us/about/about.component';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD.MM.YYYY',
  },
  display: {
    dateInput: 'MMM DD, YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  },
};

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    ListDoctorsComponent,
    AboutComponent
  ],
  entryComponents: [AddRecordFormComponent, ChangePasswordFormComponent, CreateUserFormComponent, CreateDepartmentFormComponent, CreateServiceFormComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LoginModule,
    RouterModule.forRoot(
      [
        {path: 'auth/login', component: LoginComponent},
        {path: 'auth/registration', component: RegistrationComponent},
        {path: 'account/cabinet', component: CabinetComponent, canActivate: [AuthGuard]},
        {path: 'account/cabinet/settings', component: SettingsComponent, canActivate: [AuthGuard]},
        {path: 'account/cabinet/my-records', component: MyRecordsComponent, canActivate: [AuthGuard]},
        {path: 'account/cabinet/support', component: SupportComponent, canActivate: [AuthGuard]},
        {path: 'account/admin', component: AdminPanelComponent, canActivate: [AuthGuard]},
        {path: 'departments', component: DepartmentsListComponent},
        {path: 'doctors', component: ListDoctorsComponent},
        {path: 'department/:id', component: DepartmentComponent},
        {path: 'main', component: MainPageComponent},
        {path: 'about', component: AboutComponent},
        {path: '**', redirectTo: 'main'}

      ]),
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DepartmentModule,
    AccountModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: []
      }
    }),
    BrowserAnimationsModule
  ],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: MAT_DATE_LOCALE, useValue: MY_DATE_FORMATS
    }],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
