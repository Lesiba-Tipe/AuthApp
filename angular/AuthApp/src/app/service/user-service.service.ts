import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth-service.service';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environment/environment';
import { IUserDto } from 'src/data/userDto';
import { IEmailDto } from 'src/data/EmailDto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  PATH_OF_API = environment.apiUrl + 'api/';

  requestHeader = new HttpHeaders({ 'No-Auth': 'True' });
  constructor(
    private httpclient: HttpClient,
    private authService: AuthService
  ) {}

  // EMAIL
  requstOTP(email : any) {
    const emailDto : IEmailDto = { email : email}
    return this.httpclient.post(this.PATH_OF_API + 'Account/request-otp', emailDto, {
      headers: this.requestHeader,
    });
  }

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

  requestPasswordToken(entry: any){
    return this.httpclient.post(this.PATH_OF_API + 'Account/request-password-token', entry, {
      headers: this.requestHeader,
    });
  }

  resetPassword(entry: any){
    return this.httpclient.post(this.PATH_OF_API + 'Account/reset-password', entry, {
      headers: this.requestHeader,
    });
  }

  requestEmailToken(entry: any){
    return this.httpclient.post(this.PATH_OF_API + 'Account/request-email-token', entry, {
      headers: this.requestHeader,
    });
  }

  confirmEmail(entry: any){
    return this.httpclient.post(this.PATH_OF_API + 'Account/confirm-email', entry, {
      headers: this.requestHeader,
    });
  }


  //SOCIAL
  private decodeJwtToken(googleJwtToken : any) : any{
    const decoder = new JwtHelperService();
    return decoder.decodeToken(googleJwtToken.credential);
    //console.log('CREDENTIALS: ', decodedToken)
  }

  public signInWithGoogle(googleJwtToken : any){ 
    const data = this.decodeJwtToken(googleJwtToken)

    const userDto : IUserDto = {
      firstname : data.given_name,
      lastname : data.name.substring(data.name.indexOf(" ") + 1),
      email : data.email
    }
    
    return this.httpclient.post(this.PATH_OF_API + 'account/google-sign-in', userDto, {
      headers: this.requestHeader,
    });
  }

  public signUpWithGoogle(googleJwtToken : any){ 
    const data = this.decodeJwtToken(googleJwtToken)

    return this.httpclient.post(this.PATH_OF_API + 'account/google-sign-up', data, {
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
