import { ListResponseModel } from './../models/carResponse';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

localStorage:Storage
  constructor(private httpClient:HttpClient) {
    this.localStorage=window.localStorage;
   }




  get(key:string){
    return this.localStorage.getItem(key);
  }

  set(key:string,value:string){
    this.localStorage.setItem(key,value);
  }


  remove(key:string){
    this.localStorage.removeItem(key);
  }

  clean(){
    this.localStorage.clear();
  }
}
