import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './compenents/main-layout/main-layout.component';
import { AppRoutingModule } from '../../app-routing.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MainLayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    MainLayoutComponent,
  ]
})
export class LayoutModule { }
