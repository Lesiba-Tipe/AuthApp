import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './auth/auth.gard';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { ListUserComponent } from './list-user/list-user.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './shared/dashboard/dashboard.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserComponent } from './user/user.component';
import { BuildingComponent } from './building/building/building.component';
import { VisitorListComponent } from './visitor-list/visitor-list.component';
import { RequestPasswordTokenComponent } from './request-password-token/request-password-token.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RequestConfirmEmailTokenComponent } from './request-confirm-email-token/request-confirm-email-token.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { MessegesComponent } from './messeges/messeges.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'user', component: UserComponent },
  { path: 'users', component: ListUserComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'users/:id', component: UserDetailsComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'forbidden', component: ForbiddenComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'building', component: BuildingComponent },
  { path: 'visitors-list', component: VisitorListComponent },
  { path: 'request-password-token', component: RequestPasswordTokenComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'request-confirm-email-token', component: RequestConfirmEmailTokenComponent },
  { path: 'confirm-email', component: ConfirmEmailComponent },
  { path: 'messeges', component: MessegesComponent },
  
  //{ path: 'admin', canActivate: [AuthGuard], data: { role: ['role'] }, loadChildren: () => import('./admin/admin.component').then(m => m.AdminComponent) },
  //
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
