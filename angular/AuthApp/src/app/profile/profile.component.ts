import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../service/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: any = {} as any;

  constructor(
    private profileService: ProfileService
    ) 
    {}


  ngOnInit(): void {
    console.log('ngOnit(): ProfileComponent:', this.profileService.getUser());
     this.profile = this.profileService.getUser();
  }
}
