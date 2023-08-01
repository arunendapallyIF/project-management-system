import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { ConfirmationService, MessageService, SelectItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{  products!: UserProduct[];

  constructor(private productService: ProductService) {}

  ngOnInit() {
      this.productService.getProductsData().subscribe((data) => {
          this.products=data.result;
      });
  }
}
export interface UserProduct {
  ProductId?: string;
  Name?: string;
  Description?: string;
  Price?: number;
  Quantity?: number;
  ProductCategory?: string;
  Image?: string;
  SubCategory?: number;
}
