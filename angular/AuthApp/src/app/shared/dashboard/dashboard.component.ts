import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  profile: any = {} as any;

  constructor(
    private router: Router,
    private userService: UserService,
    private authService: AuthService,
    private authGard: AuthGuard,
    private profileService: ProfileService
    ) 
    { 
      console.log('ngOnit(): DashboardComponent:', this.profileService.getUser());
      this.profile = this.profileService.getUser();  
    }

  ngOnInit(): void {
    
  }

  public isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  public logout() {
    this.authService.clear();
    this.router.navigate(['/login']);
  }

  dashboard(){
    console.log('This is dasboard....')
  }

}
