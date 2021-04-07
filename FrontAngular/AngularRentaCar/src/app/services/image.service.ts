import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/listResponseModel';
import { CarImages } from '../models/carImages';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor( private httpclient:HttpClient) { }
   apiurl="  https://localhost:44373/api/";


  //  getImages():Observable<ListResponseModel<Image>>{
  //   let newPath=this.apiurl+"carimages/getAll";
  //   return this.httpclient.get<ListResponseModel<Image>>(newPath)
  // }


  getimageByCarId(carId:number):Observable<ListResponseModel<CarImages>>{
    let newPath=this.apiurl+"carimages/getlistbycarid?id="+carId
    return this.httpclient.get<ListResponseModel<CarImages>>(newPath)
  }


}
