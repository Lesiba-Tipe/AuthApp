import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';

import { UserService } from './service/user-service.service';
import { AuthService } from './service/auth-service.service';
import { ICrudeService } from './service/icrude.service';

import { AuthGuard } from './auth/auth.gard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { DashboardComponent } from './shared/dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTable, MatTableModule } from '@angular/material/table';
import { ListUserComponent } from './list-user/list-user.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { HomeComponent } from './home/home.component';
import { BuildingComponent } from './building/building/building.component';
import { VisitorListComponent } from './visitor-list/visitor-list.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RequestPasswordTokenComponent } from './request-password-token/request-password-token.component';
import { RequestConfirmEmailTokenComponent } from './request-confirm-email-token/request-confirm-email-token.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { NotAuthaurizedComponent } from './not-authaurized/not-authaurized.component';
import { MessegesComponent } from './messeges/messeges.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent, 
    UserComponent,
    AdminComponent,
    ForbiddenComponent,
    RegisterComponent,
    ListUserComponent,
    ProfileComponent,
    UserDetailsComponent,
    HomeComponent,
    BuildingComponent,
    VisitorListComponent,
    ResetPasswordComponent,
    RequestPasswordTokenComponent,
    RequestConfirmEmailTokenComponent,
    ConfirmEmailComponent,
    NotAuthaurizedComponent,
    MessegesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    ReactiveFormsModule,
  ],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass:AuthInterceptor,
      multi:true
    },
    AuthService,
    UserService,
    ICrudeService 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
