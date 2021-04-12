import { SingleResponseModel } from './../models/singleResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ObservableInput } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Car } from '../models/car';
import { CarDetailsDto } from '../models/carDetailsDto';
import { CarDetail } from '../models/carDetail';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {

apiUrl="https://localhost:44373/api/";
  constructor(private httpClient:HttpClient) { }

  getCars():Observable<ListResponseModel<Car>>{
    let newPath=this.apiUrl+"car/getcardetails";
   return  this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarsDetail():Observable<ListResponseModel<Car>>{
    let newPath=this.apiUrl+"car/getcardetails";
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarById(carId:number):Observable<SingleResponseModel<Car>>{
    let newPath=this.apiUrl+"car/getbyid?carId="+carId;
    return this.httpClient.get<SingleResponseModel<Car>>(newPath);
  }


  getCarsByBrand(brandId:number):Observable<ListResponseModel<CarDetail>>{
    let newPath=this.apiUrl+"car/getcarbrandid?brandId="+brandId;
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath);
  }

  // getCarForDetails(carId:number):Observable<SingleResponseModel<CarDetailsDto>>{
  //    let newPath=this.apiUrl+"car/getforcardetail/"+carId
  //    return this.httpClient.get<SingleResponseModel<CarDetailsDto>>(newPath);debugger;
  // }

  // getCarImages(carId:number):Observable<ListResponseModel<CarImages>{



  // }



  addCar(car:Car):Observable<ResponseModel>{
     let newPath=this.apiUrl+"car/add";
    return this.httpClient.post<ResponseModel>(newPath,car);
  }


  updateCar(car:Car):Observable<ResponseModel>{
    let newPath=this.apiUrl+"car/update";
    return this.httpClient.post<ResponseModel >(newPath,car);
  }

}
