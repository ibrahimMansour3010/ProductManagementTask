import { AlertHelperService } from './../../../../core/helpers/alert-helper.service';
import { ProductService } from './../services/product.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductListDto } from '../../models/productListDto-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertMessageType } from '../../../../core/enums/alert-message-type';

@Component({
  selector: 'app-manage-product',
  standalone: false,

  templateUrl: './manage-product.component.html',
  styleUrl: './manage-product.component.scss',
})
export class ManageProductComponent implements OnInit {
  @Input() productDto: ProductListDto | null = null;
  @Input() isEdit: boolean = false;
  productForm: FormGroup | any;
  @Output() isSaved: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private alertHelperService: AlertHelperService
  ) {}
  ngOnInit(): void {
    debugger;
    this.productForm = this.fb.group({
      id: [this.productDto?.id],
      name: [
        this.productDto?.name,
        [Validators.required, Validators.maxLength(100)],
      ],
      description: [
        this.productDto?.description,
        (Validators.required, Validators.maxLength(500)),
      ],
      price: [
        this.productDto?.price,
        [Validators.required, Validators.min(0.01)],
      ],
    });
  }
  // Helper method to check if a control has a specific error
  hasError(controlName: string, errorName: string): boolean {
    const control = this.productForm.get(controlName);
    return control?.hasError(errorName) && control.touched;
  }

  saveProduct() {
    const product = this.productForm.value;
    if (!this.isEdit) {
      this.productService.createProduct(product).subscribe(
        (res) => {
          if (res.succeeded) {
            this.alertHelperService.showAlertMessage(
              'Product Created Successfully',
              AlertMessageType.Success
            );
            this.isSaved.emit(true);
          } else {
            this.alertHelperService.showAlertMessage(
              res.messages.join('\n'),
              AlertMessageType.Error
            );
          }
        },
        (err) => {
          this.alertHelperService.showAlertMessage(err, AlertMessageType.Error);
        }
      );
    } else {
      this.productService.updateProduct(product).subscribe(
        (res) => {
          if (res.succeeded) {
            this.alertHelperService.showAlertMessage(
              'Product Updated Successfully',
              AlertMessageType.Success
            );
            this.isSaved.emit(true);
          } else {
            this.alertHelperService.showAlertMessage(
              res.messages.join('\n'),
              AlertMessageType.Error
            );
          }
        },
        (err) => {
          this.alertHelperService.showAlertMessage(err, AlertMessageType.Error);
        }
      );
    }
  }
  cancelForm() {
    this.isSaved.emit(false);
  }
}
