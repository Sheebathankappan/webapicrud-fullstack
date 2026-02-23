import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl='https://localhost:7178/api/products';


  constructor(private http:HttpClient) { }

  getAll()
  {
    return this.http.get(this.baseUrl);
  }

  add(data: any)
  {
    return this.http.post(this.baseUrl,data);
  }
}
