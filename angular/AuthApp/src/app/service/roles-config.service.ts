import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RolesConfigService {

  constructor(private router: Router) { }

  public config(role: string): any{

    switch (role) {
      case 'Admin': 
        this.router.navigate(['/admin']);
        break;
      case 'Property-Administrator':          
        break;
      case 'Caretaker':         
        break;
      case 'Landlord':
        break;
      case 'Access-control':             
        break;
      case 'Tenant':             
        break;
      case 'Visitor':            
        break;
      default:
       this.router.navigate(['/user']);
       break;
    }

  }
}
