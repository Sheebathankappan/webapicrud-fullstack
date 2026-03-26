import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  private baseUrl = 'https://localhost:7178/api/products';

  constructor(private http: HttpClient) { }

  getProducts():Observable<any> {
    return this.http.get(this.baseUrl);
  }

}
