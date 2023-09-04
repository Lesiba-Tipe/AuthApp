import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthGuard } from '../auth/auth.gard';
import { AuthService } from '../service/auth-service.service';
import { ProfileService } from '../service/profile.service';
import { UserService } from '../service/user-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  dataSource : any;// = new MatTableDataSource<any>([]);
  addNewUserForm: any;
  user: any;

  constructor(
      private authGard: AuthGuard,
      private userService: UserService,
      private router: Router,
    ) 
    { }

  ngOnInit(): void {

    this.userService.getUsers().subscribe(
      response =>{
        console.log('Users: ',response);
        this.dataSource = new MatTableDataSource<any>(response);  //response; 
      },
      error => {

      }
    )
  }

  addNewUser(form: NgForm){
    console.log('Modal:',form.value);
  }

  onRowClick(row: any) {
    // Handle row click event 
    console.log('Row clicked:', row); 
    this.user = row;

    const id: any = '/users/' + String(row.id);
    console.log('ROUTE: ',id);

    this.router.navigate([id]);
  }
}
