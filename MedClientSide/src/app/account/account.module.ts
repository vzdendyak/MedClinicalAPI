import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CabinetComponent} from './cabinet/cabinet.component';
import {SettingsComponent} from './settings/settings.component';
import {MyRecordsComponent} from './my-records/my-records.component';
import {SupportComponent} from './support/support.component';
import {CabinetNavComponent} from '../navigation/cabinet-nav/cabinet-nav.component';
import {MaterialModule} from '../material/material.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {ChangePasswordFormComponent} from './change-password-form/change-password-form.component';


@NgModule({
  declarations: [
    CabinetComponent,
    SettingsComponent,
    MyRecordsComponent,
    SupportComponent,
    CabinetNavComponent,
    ChangePasswordFormComponent
  ],
  imports: [
    CommonModule, MaterialModule, FormsModule, ReactiveFormsModule
  ]
})
export class AccountModule {
}
