import { Component } from '@angular/core';
import { UserService } from '../service/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent {

  success = false;
  confrimEmailInput : any 
  constructor(
    private userService: UserService,
    private router: Router
  )
  {
    this.confrimEmailInput = {
      email: "canemary@microsoft.com", //Get email from url
      token: "token"  //Get email from url
    }
    this.confirmEmail()
  }

  confirmEmail(){
    this.userService.confirmEmail(this.confrimEmailInput).subscribe(
      () => {
        this.success = true        
        this.router.navigate(['/home'])
      },
      (error) =>{       
        console.log('Error:', error)
      }
    )
  }
}
