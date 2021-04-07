import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarDetail } from 'src/app/models/carDetail';
import { CarImages } from 'src/app/models/carImages';
import { CarService } from 'src/app/services/car.service';
import { CarimageService } from 'src/app/services/carimage.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
    carDetail:CarDetail;
   cars:Car[]=[];
   carDetails:CarDetail[];
   currentCar:Car;
   imageUrl=environment.apiUrl;
   carImages:CarImages[];
   filterText="";
   carId:number;

  constructor( private  carService:CarService,private activatedRoute:ActivatedRoute,
    private carImagesService:CarimageService) { }

  ngOnInit(): void {

   this.getCarsByFiltered();
    this.getImageByCarId(this.carId);
      }

      imageBaseUrl='https://localhost:44373/';



   getCars(){
     this.carService.getCars().subscribe((response)=>{
       this.cars=response.data
     });
   };


    setCurrentCar=(car:Car)=>{
      this.currentCar=car
    }



   getCarsByBrand(brandId:number){
    this.carService.getCarsByBrand(brandId).subscribe(response=>{
      this.cars=response.data;
      console.log(response.data);
    });

  }


  getImageByCarId(carId:number){
    this.carImagesService.getImagesByCarId(carId).subscribe(response=>{
      this.carImages=response.data;
    });
  }

  // getFilterBrandId(brandId:number){
  //  this.carService.getCarsByBrand(brandId).subscribe(response=>{
  //    this.carDetail=response.data;
  //  })
  // }


  getCarsByFiltered() {
    this.activatedRoute.params.subscribe(param => {
       if (param['brandId'] > 0) {
          return this.getCarsByBrand(param['brandId']);debugger;
       }


       return this.getCars();

    });
  }
  //  getCarDetailsCarId(carId:number){

  //  }

  //  getRoute(carId:number)
  // {
  //   this.router.navigateByUrl("/cars/"+carId+"/detail");
  // }

}
