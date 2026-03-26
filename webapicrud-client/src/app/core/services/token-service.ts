import { Injectable ,signal} from '@angular/core';


@Injectable({
  providedIn: 'root',
})
export class TokenService {

  private readonly TOKEN_KEY='jwt_token';

  tokenSignal=signal<string| null>(this.getToken());

  getToken():string | null{
    return localStorage.getItem(this.TOKEN_KEY);
  }

  storeToken(token:string){
    localStorage.setItem(this.TOKEN_KEY, token);
    this.tokenSignal.set(token);
  }

  clearToken()
  {localStorage.removeItem(this.TOKEN_KEY);
   this.tokenSignal.set(null);
  }

}
