import { Injectable } from '@angular/core';
import { BaseService } from '../../../../core/services/base.service';
import { Observable } from 'rxjs';
import { IApiResponse, IApiResponsePaginated } from '../../../../core/models/api-response.model';
import { ProductListDto } from '../../models/productListDto-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService {

  url:string = this.baseUrl('Product');
  constructor() {
    super();
   }


   getProductList(pageSize:number,pageNumber:number):Observable<IApiResponsePaginated<ProductListDto>>{
    return this._httpClient.get<IApiResponsePaginated<ProductListDto>>(`${this.url}/GetProductList?pageSize=${pageSize}&pageNumber=${pageNumber}`);
   }


   createProduct(ProductDto:ProductListDto):Observable<IApiResponse<number>>{
    return this._httpClient.post<IApiResponse<number>>(`${this.url}/CreateProduct`,ProductDto);
   }

   updateProduct(ProductDto:ProductListDto):Observable<IApiResponse<ProductListDto>>{
    return this._httpClient.put<IApiResponse<ProductListDto>>(`${this.url}/UpdateProduct`,ProductDto);
   }

   deleteProduct(ProductId:number|undefined):Observable<IApiResponse<ProductListDto>>{
    return this._httpClient.delete<IApiResponse<ProductListDto>>(`${this.url}/DeleteProduct`,{body:{id:ProductId}});
   }
}
