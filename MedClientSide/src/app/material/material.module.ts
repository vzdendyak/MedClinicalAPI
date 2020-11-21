import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MatDividerModule} from '@angular/material/divider';
import {HeaderComponent} from '../navigation/header/header.component';
import {FooterComponent} from '../navigation/footer/footer.component';
import {RouterModule} from '@angular/router';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDrawerContainer, MatSidenavModule} from '@angular/material/sidenav';
import {MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    MatDividerModule,
    RouterModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    MatProgressBarModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatTableModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    MatDividerModule,
    RouterModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    MatProgressBarModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatTableModule
  ]
})
export class MaterialModule {
}
