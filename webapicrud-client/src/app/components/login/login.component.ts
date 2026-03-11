import { Component, OnInit } from '@angular/core';
import {LoginService} from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private username:string;
  private password:string;


  constructor(private service:LoginService) { } 

  ngOnInit() {
    this.service.login(this.username,this.password)
    .subscribe(res=>
    {
      localStorage.setItem('token',res.token);
    });
  }

}
