import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarImages } from 'src/app/models/carImages';
import { CarService } from 'src/app/services/car.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

   cars:Car[]=[];
   currentCar:Car;
   imageUrl=environment.apiUrl;
   carImages:CarImages[];
   filterText="";

  constructor( private  carService:CarService,private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if (params["brandId"]) {
        this.getCarsByBrand(params["brandId"])
      }  else{

      this.getCars();
      }
    })
      }




   getCars(){
     this.carService.getCars().subscribe((response)=>{
       this.cars=response.data
     })
   }


    setCurrentCar=(car:Car)=>{
      this.currentCar=car
    }


   getCarsByBrand(brandId:number){
    this.carService.getCarsByBrand(brandId).subscribe(response=>{
      this.cars=response.data;
    })
  }

  //  getCarDetailsCarId(carId:number){

  //  }

  //  getRoute(carId:number)
  // {
  //   this.router.navigateByUrl("/cars/"+carId+"/detail");
  // }

}
