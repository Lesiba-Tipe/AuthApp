import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-request-confirm-email-token',
  templateUrl: './request-confirm-email-token.component.html',
  styleUrls: ['./request-confirm-email-token.component.css']
})
export class RequestConfirmEmailTokenComponent {
  success = false;

  constructor(
    private router: Router,
    private accountService: AccountService
  ){}

  RequestConfirmEmailToken(requestConfirmEmailToken: NgForm){

    this.accountService.requestEmailToken(requestConfirmEmailToken.value).subscribe(
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
