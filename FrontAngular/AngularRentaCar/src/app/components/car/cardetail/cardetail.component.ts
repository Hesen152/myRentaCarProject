import { CarImages } from 'src/app/models/carImages';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';
import { CarDetail } from 'src/app/models/carDetail';
import { CarimageService } from 'src/app/services/carimage.service';

@Component({
  selector: 'app-cardetail',
  templateUrl: './cardetail.component.html',
  styleUrls: ['./cardetail.component.css']
})
export class CardetailComponent implements OnInit {

  constructor(private carService: CarService,
    private activatedRoute: ActivatedRoute,
     private router:Router,
     private carImagesService:CarimageService,

  ) { }



  carDetail:CarDetail;
  carImages:CarImages[]=[];
  // imageUrl=environment.apiUrl;
   imageBaseUrl='https://localhost:44373/';

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
         if(params['carId']){
        this.getImageByCarId(params['carId']);
        this.getByCarId(params['carId']);

         }

    });
  }
  // this.setCarouselConfigs();


//   getCarForDetails(carId: number) {
//   this.carService.getCarForDetails(carId).subscribe((response) => {
//     this.carDetail=response.data
//     this.carImages=response.data.carImages;

//   });
// }

getByCarId(carId:number){
 this.carService.getCarById(carId).subscribe(response=>{
   this.carDetail=response.data;
 });
}



getImageByCarId(carId:number){
  this.carImagesService.getImagesByCarId(carId).subscribe(response=>{
    this.carImages=response.data;
  });
}







  }


