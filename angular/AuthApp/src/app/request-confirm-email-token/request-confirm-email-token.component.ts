import { Component } from '@angular/core';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-request-confirm-email-token',
  templateUrl: './request-confirm-email-token.component.html',
  styleUrls: ['./request-confirm-email-token.component.css']
})
export class RequestConfirmEmailTokenComponent {
  success = false;

  constructor(
    private userService: UserService,
    private router: Router
  ){}

  RequestConfirmEmailToken(requestConfirmEmailToken: NgForm){

    this.userService.requestEmailToken(requestConfirmEmailToken.value).subscribe(
      (response) =>{
        alert('Email have been sent successfully, please check your email')
        this.router.navigate(['/home']) // Navigate to home
      },
      (error) =>{
        console.log('ERROR: ', error)
        alert('Email could not be sent. An error occured.')
      }
    )

  }
}
