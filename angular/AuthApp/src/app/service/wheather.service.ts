import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WheatherService {

  private headers: HttpHeaders;
  
  constructor(
    private httpclient: HttpClient,
  ) {

  this.headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });
  }

  getWeather(){
    const api_key = "d322e85cc6a4fe4a3c70f208a9822a2e"
    const url = `http://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=${api_key}`

    return this.httpclient.get<any>(url, {headers: this.headers});
  }
}
