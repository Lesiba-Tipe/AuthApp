import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ICrudeService } from 'src/app/service/icrude.service';

@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent {

  building : any
  constructor(
    private crud: ICrudeService,
  ){

  }

  addNewBuilding(form: NgForm){
    console.log('New building:', form.value)

    this.crud.Insert(form.value,'building').subscribe(
      (response) =>{

      },
      (error) =>{
        alert('Error: Could not perform request')
        console.log(`ERROR-BUILDING: ${error}`)
      }
    )
  }
}
