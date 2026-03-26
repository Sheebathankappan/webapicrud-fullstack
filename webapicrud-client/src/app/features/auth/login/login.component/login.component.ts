import { Component, inject,ChangeDetectorRef } from '@angular/core';
import { AuthService } from '../../../../core/services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {

  private authService=inject(AuthService);
  private cdr=inject(ChangeDetectorRef);

  username='';
  password='';

  error='';

  loading=false;

 login()
 {
  this.loading=true;
  this.authService.login({
    username:this.username,
    password:this.password}).subscribe({
      next: ()=>{
        this.loading=false;
        this.cdr.detectChanges();
        console.log('Login successful');
      },
      error : ()=>
      {
        this.error='Login failed';
        this.loading=false;
        this.cdr.detectChanges();
      }
    });
 }
}
