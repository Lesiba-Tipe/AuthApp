import { Injectable } from '@angular/core';
import { Profile } from 'src/data/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private profile! : Profile;

  setUser(_profile: Profile){
    this.profile = _profile;
  }

  getUser(): Profile{
    return this.profile; 
  }

}
