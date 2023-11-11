import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-request-password-token',
  templateUrl: './request-password-token.component.html',
  styleUrls: ['./request-password-token.component.css']
})
export class RequestPasswordTokenComponent {
 
  success = false;
  constructor(
    private userService: UserService,
    private router: Router
  ) {}
  
  RequestPasswordToken(RequestPasswordTokenForm: NgForm) {
    console.log('log-in button pressed.... ')
    
    this.userService.requestPasswordToken(RequestPasswordTokenForm.value).subscribe(
      (response: any) => { 
        this.success = true        
        //this.router.navigate(['/'])
      },
      (error) => {
        console.log("ERROR <RequestPasswordTokenForm> : ", error)             
      }
      );
  }

}
