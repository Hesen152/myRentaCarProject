import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarImages } from '../models/carImages';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})

export class CarimageService {
  apiUrl: string = 'https://localhost:44373/api/carImages/';

  constructor( private httpclient:HttpClient) { }

  getImagesByCarId(carId:number):Observable<ListResponseModel<CarImages>>{
    let newPath=this.apiUrl+"getlistbycarid?id="+carId;
    return this.httpclient.get<ListResponseModel<CarImages>>(newPath);
  }
}
