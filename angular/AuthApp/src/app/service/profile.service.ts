import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private profile : any;

  setUser(_profile: any){
    this.profile = _profile;
  }

  getUser(): any{
    return this.profile; 
  }
}
