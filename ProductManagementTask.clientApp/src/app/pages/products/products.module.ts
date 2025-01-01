import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ManageProductComponent } from './components/manage-product/manage-product.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    ProductListComponent,
    ManageProductComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    SharedModule
  ]
})
export class ProductsModule { }
