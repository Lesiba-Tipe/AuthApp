import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth-service.service';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ProfileService } from '../service/profile.service';
import { environment } from 'src/environment/environment';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { RolesConfigService } from '../service/roles-config.service';
import { Profile } from 'src/data/profile';
import { AccountService } from '../service/account.service';



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
    private rolesConfigService: RolesConfigService,
    //private authGard: AuthGuard,
    private profileService: ProfileService,
    private accountService: AccountService
  ) {

  }

  ngOnInit(): void {
    this.handleGoogleSignIn();
  }

  handleCredentialResponse(credentialResponse: CredentialResponse) {

    this.accountService.signInWithGoogle(credentialResponse).subscribe(
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
    
    this.accountService.login(loginForms.value).subscribe(
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
        console.log('ROLE:', role)

        //Initialize user
        //this.initilize_Profile()

        this.router.navigate(['/home']);       
  }

  initilize_Profile(){
    this.userService.getUserById(this.authService.getId()).subscribe(
      (response: any) => {
        const profile: Profile = response;
        profile.roles = this.authService.getRoles();
        this.profileService.setUser(profile);
        console.log('PROFILE',profile)

      },
      (error) =>{
        console.log('Failed to get Profile by Id: ',error);
      }
    );      
  }

}
