import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
  } from '@angular/common/http';
  import { Router } from '@angular/router';
  import { catchError } from 'rxjs/operators';
  import { Observable, throwError } from 'rxjs';
  import { Injectable } from '@angular/core';
import { AuthService } from '../service/auth-service.service';
  
  @Injectable()
  export class AuthInterceptor implements HttpInterceptor {
  
    constructor(private authService :AuthService, private router :Router) {}
  
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       console.log('AuthInterceptor-intercept()')

      if (req.headers.get('No-Auth') === 'True') {
        return next.handle(req.clone());
      }
  
      const token = this.authService.getToken();
      console.log('Token: ');
      req = this.addToken(req, token);
  
      return next.handle(req).pipe(
          catchError(
              (err:HttpErrorResponse) => {
                  console.log('Interceptor Error:' + err.status);
                  if(err.status === 401) {
                      this.router.navigate(['/login']);
                  } else if(err.status === 403) {
                      this.router.navigate(['/forbidden']);
                  }
                  return throwError("Something went wrong");
              }
          )
      );
    }
  
  
    private addToken(request:HttpRequest<any>, token:string) {
        return request.clone(
            {
                setHeaders: {
                    Authorization : `${token}`
                }
            }
        );
    }
  }
  