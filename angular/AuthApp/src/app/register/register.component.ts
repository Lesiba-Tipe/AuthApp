import { Component } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
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
  _alert = new FormControl('This is alert')

  constructor(
    private userService: UserService,
    private router: Router,
  ){}

  register(registerForm: NgForm){
    console.log('for data: ', registerForm.value)
    this.registerUser(registerForm);
    
    
  }

  registerUser(form: NgForm){
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
        console.log('See error: ', error); // use logs
      }

    );
  }
}
