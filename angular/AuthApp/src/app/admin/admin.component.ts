import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthGuard } from '../auth/auth.gard';
import { AuthService } from '../service/auth-service.service';
import { ProfileService } from '../service/profile.service';
import { UserService } from '../service/user-service.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit {
  //
  constructor(
      private authGard: AuthGuard,
    ) 
    { }

  ngOnInit(): void {

    
  }


}
