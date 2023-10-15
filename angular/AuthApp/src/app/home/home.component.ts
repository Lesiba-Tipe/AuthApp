import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { WheatherService } from '../service/wheather.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  year =  new Date().getFullYear()
  constructor(private weatherService: WheatherService){ 

   }

   ngOnInit(): void {
    //console.log("WEATHER")
    this.weatherService.getWeather().subscribe(
      response =>{
        console.log(`RESPONSE: ${response}`)
      },
      error =>{
        console.log(`ERROR: ${error}`)
      }
    )
  }
}
