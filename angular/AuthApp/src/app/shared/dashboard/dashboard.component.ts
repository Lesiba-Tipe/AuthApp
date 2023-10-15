import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, elementAt } from 'rxjs';
import { AuthGuard } from 'src/app/auth/auth.gard';
import { AuthService } from 'src/app/service/auth-service.service';
import { ProfileService } from 'src/app/service/profile.service';
import { UserService } from 'src/app/service/user-service.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {

  private _profile$!: Observable<any>;
  profile: any = {} as any;
  count = 0

  property_admin = false;
  caretaker = false;
  landlord = false;
  access_control = false;
  tenant = false;
  visitor = false;
  user = false;

  constructor(
    private router: Router,
    private userService: UserService,
    private authService: AuthService,
    private authGard: AuthGuard,
    private profileService: ProfileService
    ) 
    { }

  ngOnInit(): void {
    this.initilize_Profile()
    console.log('ngOnInit(): DashboardComponent ',this.count++)
  }

  public isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  public logout() {
    this.authService.clear();
    this.router.navigate(['/login']);
  }
  
  initilize_Profile(){
    if(this.authGard){
      this._profile$ = this.userService.getUserById(this.authService.getId());
      
      this._profile$.subscribe(
        (response: any) => {
          console.log('Initilize Response: ',response)
          console.log('ROLES: ',this.authService.getRoles())

          this.profileService.setUser(response);
          this.profile = response;

          const role = this.authService.getRoles();
          switch (role[0]) {
            case 'Admin': 
              this.property_admin = true
              break;
            case 'Property-Administrator':
                this.property_admin = true
              break;
            case 'Caretaker': 
            //this.caretaker = true;        
              break;
            case 'Landlord':
              this.landlord = true;
              break;
            case 'Access-control':
              this.access_control = true;             
              break;
            case 'Tenant':  
            this.tenant = true;         
              break;
            case 'Visitor':  
            this.visitor = true;          
              break;
            default:
              break;
          }
        },
        (error) =>{
          console.log('Failed to get Profile by Id: ',error);
        }
      );      
    }
  }


}
