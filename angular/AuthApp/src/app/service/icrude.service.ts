import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ICrudeService {

  path = environment.apiUrl + 'api/';

  requestHeader = new HttpHeaders({ 'No-Auth': 'True' });
  constructor(
    private httpclient: HttpClient
  ) {}

  Insert(entry: any, controller: string) {
    return this.httpclient.post(this.path + controller + '/create', entry, {
      headers: this.requestHeader,
    });
  }

  public getAll(): Observable<any[]> {
    console.log('UserService-getUsers()')
    return this.httpclient.get<any>(this.path + 'user/users');
  }

  public findById(id: string) {
    return this.httpclient.get<any>(this.path + `user/${id}`);
  }

  update(id: number | string, entry: any) {
    return this.httpclient.put(this.path + `user/${id}`, entry);
  }



}
