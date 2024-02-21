import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../service/auth-service.service';
import { AccountService } from '../service/account.service';


@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private accountService: AccountService
  ) {}

  canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot) :
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree 
    
  {
    console.log('AuthGard-canActivate()')

    if (this.authService.getToken() !== null) {
      const role = route.data['roles'] as string[];
      console.log('Current User Role: ' + role)

      if (role) {
        const match = this.accountService.roleMatch(role);

        console.log('match: ', match);
        if (match) {
          return true;
        } else {
          this.router.navigate(['/forbidden']);   //UnAuthorized user eg. User trying access Admin router.
          return false;
        }
      }
    }
    this.router.navigate(['/login']);
    return false;
  }
}
