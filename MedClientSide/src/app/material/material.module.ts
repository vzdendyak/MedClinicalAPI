import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MatDividerModule} from '@angular/material/divider';
import {HeaderComponent} from '../navigation/header/header.component';
import {FooterComponent} from '../navigation/footer/footer.component';
import {RouterModule} from '@angular/router';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    MatDividerModule,
    RouterModule

  ],
  exports: [
    HeaderComponent,
    FooterComponent]
})
export class MaterialModule {
}
