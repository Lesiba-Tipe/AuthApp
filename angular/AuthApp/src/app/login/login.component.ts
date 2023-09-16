import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth-service.service';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthGuard } from '../auth/auth.gard';
import { ProfileService } from '../service/profile.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  invalidLogin: boolean = false;
  registeredSuccessfully: boolean = false;
  public response!: { dbPath: ''; };

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private router: Router,
    private authGard: AuthGuard,
    private profileService: ProfileService
  ) {}


  ngOnInit(): void {}

  login(loginForms: NgForm) {
    console.log('log-in button pressed.... ')
    
    this.userService.login(loginForms.value).subscribe(
      (response: any) => {
        this.invalidLogin = false;

        this.authService.setToken(response.jwtToken);
        console.log(response.jwtToken)

        this.authService.setRoles(response.roles);
        this.authService.setId(response.id);

        const role = response.roles[0];

        if(role === 'Admin') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/user']);
        }
        
      },
      (error) => {   
      
        if(error.status === 0)
        {
            alert('Server is not available, Please try again later');
        }
        else{
          var displayErrorAlert = document.getElementById('login-error-alert');   

          if(displayErrorAlert){ 
            displayErrorAlert.style.display = "block";           
          }

          setTimeout(() => {
            if(displayErrorAlert) { 
              displayErrorAlert.style.display = "none"; 
            }
          }, 5000);

          this.invalidLogin = true; 

          console.log('STATUS: ', error.status)
          console.log('ERROR: ', error)
        }
      }
    );
  }


}
