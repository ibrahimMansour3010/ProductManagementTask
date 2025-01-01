import { Component, inject, ViewChild, viewChild } from '@angular/core';
import { ProductListDto } from '../../models/productListDto-model';
import { AlertHelperService } from '../../../../core/helpers/alert-helper.service';
import { ProductService } from '../services/product.service';
import { AlertMessageType } from '../../../../core/enums/alert-message-type';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-product-list',
  standalone: false,

  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent {
  pageSize: number = 5;
  pageNumber: number = 0; // Start with 0 as p-table uses zero-based index
  totalRecords: number = 0;
  products: ProductListDto[] = [];
  showDialog: boolean = false;
  selectedProduct: ProductListDto | null = null;
  isShowDeleteDialog: boolean = false;
  searchValue: string | undefined;

  @ViewChild('dt1') dt1:any;
  // Inject dependencies
  readonly alertHelper = inject(AlertHelperService);
  readonly productService = inject(ProductService);
  readonly alertHelperService = inject(AlertHelperService);

  ngOnInit() {
    this.getProductsList();
  }
  filterTable(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const searchValue = inputElement.value || ''; // Safely access the value
    this.dt1.filterGlobal(searchValue, 'contains');
  }
  getProductsList() {
    debugger;
    this.productService
      .getProductList(this.pageSize, this.pageNumber)
      .subscribe((res) => {
        this.products = res.data.result;
        this.totalRecords = Number(res.data.allItemCount);
      });
  }

  pageChange(event: any) {
    debugger;
    this.pageNumber = event.first / event.rows; // Calculate zero-based page number
    this.pageSize = event.rows;
    this.getProductsList();
  }

  showManageDialog(product: ProductListDto | null) {
    this.showDialog = true;
    this.selectedProduct = product;
  }
  closeDialog(isSaved: boolean) {
    this.showDialog = false;
    if (isSaved) this.getProductsList();
    this.selectedProduct = null;
  }
  showDeleteDialog(product: ProductListDto) {
    this.selectedProduct = product;
    this.isShowDeleteDialog = true;
  }
  clear(table: Table) {
    table.clear();
    this.searchValue = '';
  }
  closeDeleteDialog(isDelete: boolean) {
    debugger;
    if (isDelete) {
      this.productService
        .deleteProduct(this.selectedProduct?.id)
        .subscribe((res) => {
          if (res.succeeded) {
            this.alertHelper.showAlertMessage(
              'Product Has Been Deleted Successfully'
            );
            this.selectedProduct = null;
            this.getProductsList();
          }
        });
    }
    this.isShowDeleteDialog = false;
  }
}
