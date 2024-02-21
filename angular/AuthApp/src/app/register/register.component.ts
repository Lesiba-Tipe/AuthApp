import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../service/user-service.service';
import { environment } from 'src/environment/environment';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { IEmailDto } from 'src/data/EmailDto';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm: any;
  registeredSuccessfully: boolean = false;
  formGroupRegister: FormGroup;
  submitted = false;

  constructor(
    private userService: UserService,
    private router: Router,
    private fb: FormBuilder,
    private accountService: AccountService
  ){

    this.formGroupRegister = fb.group({
      firstname: ['', Validators.required],
       lastname:['', Validators.required],
       email:  ['', [Validators.required, Validators.email]],
       //confirmEmail: ['', Validators.required],
       phoneNumber:'',
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword:['', Validators.required],
      
    },
    {
      Validators: this.passwordMatchValidator()
    })

    this.handleGoogleSignUp()
  }

  get f(){ return this.formGroupRegister.controls }

  register(){
    this.submitted = true;

    if(this.formGroupRegister.valid){
      console.log('this.registerForm.valid')
      console.log('Firstname: ', this.formGroupRegister.get('firstname')?.value)
      console.log('for data: ', this.formGroupRegister.value)
      this.registerUser(this.formGroupRegister);
      
    }else{
      console.log("ERRROR<Register>: ", this.formGroupRegister.errors)
    }
    
  }

  registerUser(form: FormGroup){

    this.accountService.register(form.value).subscribe(
      (response: any) => {
          console.log('Response from API: ' + response);
          //this.registeredSuccessfully = true;

          if(response){            
            this.registeredSuccessfully = true;  
            setTimeout(() => {
              this.registeredSuccessfully = false;
            }, 5000);
            this.router.navigate(['/login'])
          }
      },
      (error) => {
        console.log('Error from API: ' + error)
        this.showError()
        console.log('See error: ', error); // use logs
      }

    );
  }

  showError(){

        var displayErrorAlert = document.getElementById('add-error-alert');

        if(displayErrorAlert)
        { 
          displayErrorAlert.style.display = "block"; 
        }

        setTimeout(() => {
          if(displayErrorAlert) { 
            displayErrorAlert.style.display = "none"; 
          }
        }, 5000);
        
  }

  passwordMatchValidator(): ValidatorFn {
    console.log('passwordMatchValidator:')
    return (control: AbstractControl): 
    { [key: string]: any } | null => 
      {
        const password = control.get('password');
        const confirmPassword = control.get('confirmPassword');
    
        if (password && confirmPassword && password.value != confirmPassword.value) {
          console.log('passwordMismatch:')
          return { passwordMismatch: true };
        }
      return null;
    };
  }

  handleGoogleSignUp() {
    // @ts-ignore
    window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: environment.clientId,
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      // @ts-ignore
      google.accounts.id.renderButton(
      // @ts-ignore
      document.getElementById("btn_googleSignUp"),
        { theme: "outline", size: "large", width: "100%" } 
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    };
  }

  handleCredentialResponse(credentialResponse: CredentialResponse) {
    this.accountService.signInWithGoogle(credentialResponse).subscribe(
      (response: any) => {  //Returns decoded JWT
        //this.onSuccess(response)               
        console.log('GOOGLE: ' + response)
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

  //=====================================================
  OTP : number = 0
  email : string = "";
 
  requestOTP(email: any){

    if(email !== ""){
      console.log('OTP: ',email)
    
      this.accountService.requstOTP(email).subscribe(
        (response: any) => {
          
          console.log('OTP CODE: ',response.code)
          
        }
      )
    }
  }

  verifyOTP(){
    
  }
}
