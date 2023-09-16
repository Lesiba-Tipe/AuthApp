import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './auth/auth.gard';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ListUserComponent } from './list-user/list-user.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './shared/dashboard/dashboard.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'user', component: UserComponent },
  { path: 'users', component: ListUserComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'users/:id', component: UserDetailsComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'forbidden', component: ForbiddenComponent },
  { path: 'register', component: RegisterComponent },
  //{ path: 'admin', canActivate: [AuthGuard], data: { role: ['role'] }, loadChildren: () => import('./admin/admin.component').then(m => m.AdminComponent) },
  // ...
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }