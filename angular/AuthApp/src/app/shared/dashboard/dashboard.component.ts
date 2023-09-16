import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
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
          this.profileService.setUser(response);
          this.profile = response;
        },
        (error) =>{
          console.log('Failed to get Profile by Id: ',error);
        }
      );      
    }
  }


}
