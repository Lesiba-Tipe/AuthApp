import { Component, OnInit } from '@angular/core';
import { AuthGuard } from '../auth/auth.gard';
import { Observable } from 'rxjs';
import { AuthService } from '../service/auth-service.service';
import { ProfileService } from '../service/profile.service';
import { UserService } from '../service/user-service.service';
import { MatTableDataSource,MatTableModule } from '@angular/material/table';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

//import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css'],
})
export class ListUserComponent implements OnInit {

  dataSource : any;// = new MatTableDataSource<any>([]);
  addNewUserForm: any;
  user: any;
  clickedRows = new Set<any>();
  //clickedRows = new Set<PeriodicElement>();

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
        console.log('User-List-ERROR',error)
      }
    )
  }

  addNewUser(form: NgForm){
    console.log('Modal:',form.value);
  }

  //Navigate to clicked user
  onRowClick(user: any) {
    // Handle row click event 
    console.log('Row clicked:', user); 
    this.user = user;

    const id: any = '/users/' + String(user.id);
    console.log('ROUTE: ',id);

    this.router.navigate([id]);
  }

  editUser(event: Event, user: any){
    event.stopPropagation();
    if(user){
      this.user = user;
      //Edit user

      // this.userService.edit(user).subscribe(
      //   ()=>{

      //     console.log('Edit clicked...',user)
      //   },
      //   ()=>{
          
      //   }
      // )


    }
  }

  deleteUser(event: Event, user: any){
    event.stopPropagation();
    if(user){     
      this.userService.delete(user.id).subscribe(
        ()=>{

        },
        ()=>{

        }
      )
    }

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
