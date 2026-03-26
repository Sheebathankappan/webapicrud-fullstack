import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginRequest} from '../models/login-request';
import { LoginResponse } from '../models/login-response';
import { TokenService } from './token-service';
import { Observable,tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class AuthService {

  private readonly http= inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7178/api/auth';
  private readonly tokenService = inject(TokenService);

  constructor(){}

  login(credentials:LoginRequest):Observable<LoginResponse>{
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe
    (tap(response=>{
      this.tokenService.storeToken(response.token);
    }))
}

logout(){
  this.tokenService.clearToken();
  }
  
}
