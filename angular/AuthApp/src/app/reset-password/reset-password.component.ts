import { Component } from '@angular/core';
import { UserService } from '../service/user-service.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})

export class ResetPasswordComponent {

  constructor(
    private userService: UserService
  ) {}
  
  ResetPassword(resetPasswordForm: NgForm) {
    console.log('log-in button pressed.... ')
    
    this.userService.resetPassword(resetPasswordForm.value).subscribe(
      (response: any) => {
        //this.onSuccess(response) 
        // response is token  
        console.log("RequestPasswordTokenForm:", response)     
      });
  }
}
