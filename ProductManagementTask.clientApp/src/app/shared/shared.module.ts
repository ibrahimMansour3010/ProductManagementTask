import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { ConfirmComponent } from './compenents/confirm/confirm.component';
import { LoaderComponent } from './compenents/loader/loader.component';
import { NoDataAvailableComponent } from './compenents/no-data-available/no-data-available.component';
import { LayoutModule } from './layout/layout.module';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabel } from 'primeng/floatlabel';
import { InputNumberModule } from 'primeng/inputnumber';
import { PaginatorModule } from 'primeng/paginator';
import { TextareaModule  } from 'primeng/textarea';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';

@NgModule({
  declarations: [
    ConfirmComponent,
    LoaderComponent,
    NoDataAvailableComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    LayoutModule,
    TableModule,
    ButtonModule,
    RouterModule,
    DialogModule,
    ReactiveFormsModule,
    InputTextModule,
    InputNumberModule,
    FloatLabel,
    PaginatorModule,
    TextareaModule,
    IconFieldModule,
    InputIconModule
  ],
  exports:[
    LayoutModule,
    TableModule,
    ButtonModule,
    ConfirmComponent,
    LoaderComponent,
    NoDataAvailableComponent,
    RouterModule,
    DialogModule,
    ReactiveFormsModule,
    InputTextModule,
    InputNumberModule,
    FloatLabel,
    PaginatorModule,
    TextareaModule,
    IconFieldModule,
    InputIconModule
  ],
})
export class SharedModule { }
