import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth-service.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  PATH_OF_API = 'https://localhost:44331/api/';

  requestHeader = new HttpHeaders({ 'No-Auth': 'True' });
  constructor(
    private httpclient: HttpClient,
    private authService: AuthService
  ) {}

  //ACCOUNT
  register(entry: any) {
    return this.httpclient.post(this.PATH_OF_API + 'Account/register', entry, {
      headers: this.requestHeader,
    });
  }

  public login(loginData: any) {
    return this.httpclient.post(this.PATH_OF_API + 'Account/login', loginData, {
      headers: this.requestHeader,
    });
  }

  //USERS
  public getUsers(): Observable<any[]> {
    console.log('UserService-getUsers()')
    return this.httpclient.get<any>(this.PATH_OF_API + 'user/users');
  }


  public getUserById(id: string) {
    return this.httpclient.get<any>(this.PATH_OF_API + `user/${id}`);
  }

  
  
  updateUser(id: number | string, entry: any) {
    return this.httpclient.put(this.PATH_OF_API + `user/${id}`, entry);
  }


  public roleMatch(allowedRoles :string[]) : boolean | any{
    let isMatch = false;
    const userRoles: any = this.authService.getRoles();

    if (userRoles != null && userRoles) {
      for (let i = 0; i < userRoles.length; i++) {
        for (let j = 0; j < allowedRoles.length; j++) {
          if (userRoles[i] === allowedRoles[j]) {
            isMatch = true;
            return isMatch;
          } else {
            return isMatch;
          }
        }
      }
    }//else return isMatch;
  }

  public forUser() {
    return this.httpclient.get(this.PATH_OF_API + 'api/forUser', {
      responseType: 'text',
    });
  }
  
  public forAdmin() {
    return this.httpclient.get(this.PATH_OF_API + 'api/forAdmin', {
      responseType: 'text',
    });
  }


}
