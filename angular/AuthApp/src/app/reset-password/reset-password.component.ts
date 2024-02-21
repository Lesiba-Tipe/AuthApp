import { Component } from '@angular/core';
import { UserService } from '../service/user-service.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})

export class ResetPasswordComponent {

  success = false;
  resetPasswordInput: any

  constructor(
    private accountService: AccountService,
    private router: Router
  ) {
     
    this.resetPasswordInput = {
      email : "", //get email from link
      token: "token", //get email from link
      password: null
    }

  }
  
  ResetPassword(resetPasswordForm: NgForm) {
    console.log(this.resetPasswordInput)
    
    if(resetPasswordForm.value){
      this.resetPasswordInput.password = resetPasswordForm.value.Password
      // Populate data
      this.accountService.resetPassword(this.resetPasswordInput).subscribe(
        (response: any) => {
          //this.success = true;
          alert('Password have been reset successfully.')
          this.router.navigate(['/login'])
          //console.log("RequestPasswordTokenForm:", response)
        },
        (error: any) =>{
          console.log("ResetPassword ERROR:", error.error.errors)
      })
    }
    
  }
}
