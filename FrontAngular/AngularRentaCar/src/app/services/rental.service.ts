import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  rentingCar:Rental;

  apiUrl="https://localhost:44373/api/";


  constructor( private httpCLient:HttpClient) { }

  getAllRentals():Observable<ListResponseModel<Rental>>{

    let newPath=this.apiUrl+"rental/getrentaldetails";
    return this.httpCLient.get<ListResponseModel<Rental>>(newPath)
  }

  setRentingCar(rental:Rental){
    this.rentingCar=rental;
  }


  getRentingCar(){
    this.rentingCar==null
  }

  removeRentingCar(){
    this.rentingCar==null;
  }


 getRentalByCarId(carId:number):Observable<ListResponseModel<Rental>>{
   let newPath=this.apiUrl+'rental/getrentalbycarid/'+carId;
   return this.httpCLient.get<ListResponseModel<Rental>>(newPath);
 }


}
