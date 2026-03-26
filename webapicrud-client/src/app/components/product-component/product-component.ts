import { Component,OnInit,ChangeDetectorRef } from '@angular/core';
import { ProductService } from '../../services/product-service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-product-component',
 standalone: true,
  imports: [CommonModule],
  templateUrl: './product-component.html',
  styleUrl: './product-component.css',
})
export class ProductComponent {
  products:any[] = [];
  constructor(private productService: ProductService,
    private cdr: ChangeDetectorRef 
  ) { }

  ngOnInit(){
    this.productService.getProducts().subscribe({ next: (data) => {
      console.log('API Response:', data);
      this.products = data; // Handle both array and object with $values
      console.log('Products:', this.products);

      this.cdr.detectChanges();

       console.log('Change detection forced');
    },
    error: (error) => {
      console.error('Error fetching products:', error);
    }
  });
}
}
