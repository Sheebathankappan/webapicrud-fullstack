import { Component } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  title = 'webapicrud-client';
  products:any;

  constructor(private api:ApiService){}

 ngOnInit()
 {
  this.api.getAll().subscribe({
    next:(res)=>
      this.products=res,
    error:(er)=>
      console.log(er)
  })
 }

}

