import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from 'app/models/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl='https://localhost:7178/api/Auth/login';

  constructor(private http:HttpClient) { }

  login(username:string, password:string)
  {
    return this.http.post<LoginResponse>(this.baseUrl,{
      username:username,
      password:password
    });
  }
}
