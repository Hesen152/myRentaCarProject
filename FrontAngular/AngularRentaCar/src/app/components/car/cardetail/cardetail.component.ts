import { CarImages } from 'src/app/models/carImages';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cardetail',
  templateUrl: './cardetail.component.html',
  styleUrls: ['./cardetail.component.css']
})
export class CardetailComponent implements OnInit {

  constructor(private carService: CarService,
    private activatedRoute: ActivatedRoute,

  ) { }


  car: Car;
  carImages:CarImages[];
  imageUrl=environment.apiUrl;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
         if(params["carId"]){
        this.getCarForDetails(params["carId"]);
         }

    });
  }
  // this.setCarouselConfigs();


  getCarForDetails(carId: number) {
  this.carService.getCarForDetails(carId).subscribe((response) => {
    this.car=response.data
    this.carImages=response.data.carImages;

  });
}





  }


