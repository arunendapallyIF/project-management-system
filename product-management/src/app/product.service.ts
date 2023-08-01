import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserProduct } from './app.component';
    
@Injectable()
export class ProductService{
    constructor(private http: HttpClient) {
    }
    getProductsData():Observable<any> {
        return this.http.get('https://localhost:44369/api/Products/v1/product');
      }
   
    getProducts() {
        return Promise.resolve(this.getProductsData());
    }

};