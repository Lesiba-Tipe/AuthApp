import { Component, OnInit  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../service/user-service.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  user : any;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private location: Location
  ){}


  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    this.getUser();
  }

  getUser(){
    const id = this.route.snapshot.paramMap.get('id');

    if(id){   //Altentive use ! instead this.userService.getUserById(id!).subscribe().......
      console.log('ID FETCHED: ', id)
      this.userService.getUserById(id).subscribe(
        response =>{
          this.user = response;
          console.log('RESPONSE: ',response)
        },
        error =>
        {
          console.log('ERROR: ', error)
        }
      )
    }
  }

  goBack(){
    this.location.back();
  }

}
