import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../service/user-service.service';

@Component({
  selector: 'app-request-password-token',
  templateUrl: './request-password-token.component.html',
  styleUrls: ['./request-password-token.component.css']
})
export class RequestPasswordTokenComponent {
 
  constructor(
    private userService: UserService
  ) {}
  
  RequestPasswordToken(RequestPasswordTokenForm: NgForm) {
    console.log('log-in button pressed.... ')
    
    this.userService.requestPasswordToken(RequestPasswordTokenForm.value).subscribe(
      (response: any) => {
        //this.onSuccess(response) 
        // response is token  
        console.log("RequestPasswordTokenForm:", response)     
      },
      () =>{
        
      }
      );
  }

}
