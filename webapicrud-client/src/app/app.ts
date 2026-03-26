import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductComponent } from './components/product-component/product-component';
import { LoginComponent } from './features/auth/login/login.component/login.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ProductComponent,LoginComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('webapicrud-client');
}
