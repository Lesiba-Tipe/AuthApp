import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../service/user-service.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  registerForm: any;
  registeredSuccessfully: boolean = false;
  formGroupRegister: FormGroup;

  constructor(
    private userService: UserService,
    private router: Router,
    private fb: FormBuilder
  ){
    this.formGroupRegister = fb.group({
      firstname: ['', Validators.required],
      lastname:['', Validators.required],
      email:  ['', [Validators.required, Validators.email]],
      phoneNumber:'',
      password: ['', Validators.required, Validators.minLength(6)],
      confirmPassword:['', Validators.required],

    },
    {
      Validators: this.passwordMatchValidator()
    })

  }

  register(){

    if(this.formGroupRegister.valid){
      console.log('Password: ', this.formGroupRegister.get('password')?.value)
        console.log('for data: ', this.formGroupRegister.value)
        //this.registerUser(this.formGroupRegister);
      
    }
    
  }

  registerUser(form: FormGroup){
    this.userService.register(form.value).subscribe(
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
    return (control: AbstractControl): { [key: string]: any } | null => {
      const password = control.get('password');
      const confirmPassword = control.get('confirmPassword');
  
      if (password && confirmPassword && password.value !== confirmPassword.value) {
        console.log('passwordMismatch:')
        return { passwordMismatch: true };
      }
      return null;
    };
  }

}
