import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth-service.service';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthGuard } from '../auth/auth.gard';
import { ProfileService } from '../service/profile.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  invalidLogin: boolean = false;
  registeredSuccessfully: boolean = false;

  private clientId = environment.clientId
  
  constructor(
    private userService: UserService,
    private authService: AuthService,
    private router: Router,
    //private authGard: AuthGuard,
    //private profileService: ProfileService,
  ) {

  }


  ngOnInit(): void {
    this.handleGoogleSignIn();
  }

  handleCredentialResponse(credentialResponse: CredentialResponse) {

    this.userService.signInWithGoogle(credentialResponse).subscribe(
      (response: any) => {
        console.log('On Success' + response)
        this.onSuccess(response)               
      },
      (error) => {   
        const status = error.status
        switch (status) {
          case 0:
            alert('Server is not available, Please try again later');
            break;
          case 401:
            alert('Unauthorize');
            break;
          default:
            alert('Error: ' + status + '| ' + error)
            break;
        }      
          console.log('STATUS: ', status)
          console.log('ERROR: ', error)       
      }
    );
      
  }

  login(loginForms: NgForm) {
    console.log('log-in button pressed.... ')
    
    this.userService.login(loginForms.value).subscribe(
      (response: any) => {
        this.onSuccess(response)        
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

  handleGoogleSignIn() {
    // @ts-ignore
    window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: this.clientId,
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      // @ts-ignore
      google.accounts.id.renderButton(
      // @ts-ignore
      document.getElementById("btn_googleSignIn"),
        { theme: "outline", size: "large", width: "100%" } 
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    };
  }
 
  onSuccess(response: any){
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
  }

}
