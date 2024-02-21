import { Component } from '@angular/core';
import { AuthService } from '../service/auth-service.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  data : any; //["Users", "Buildings"]

  constructor(
    private authService: AuthService,
    private router: Router
  ){}


  ngOnInit(): void {
    var role = this.authService.getRoles()
    switch(role[0]){
      case 'Admin': 
        this.data = ["Users", "Buildings"]
      break;
      default:
        this.data = ["My Apartment"]
        break;
    }

  }

  navigateToCard(item: string):void{
    switch(item){
      case 'Admin': 
        this.router.navigate(['/site-administration',item])
      break;
      default:
        this.router.navigate(['/forbidden'])
        break;
    }
  }
}
