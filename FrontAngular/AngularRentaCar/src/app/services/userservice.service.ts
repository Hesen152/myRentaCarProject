import { FakeFIndeksModel } from './../models/fakeIndeksModel';
import { ListResponseModel } from './../models/listResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable, ObservedValueOf } from 'rxjs';
import { SingleResponseModel } from '../models/singleResponseModel';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class UserserviceService {
  apiUrl="https://localhost:44373/api/";

  constructor(private httpClient:HttpClient) { }

  getUsers(email:string):Observable<ListResponseModel<User>>{
    return this.httpClient.get<ListResponseModel<User>>(this.apiUrl+'users')
   }


  getByEmail(email:string):Observable<SingleResponseModel<User>>{

return this.httpClient.get<SingleResponseModel<User>>(this.apiUrl+'users/getbyMail/email')
  }


  profileUpdate(user:User):Observable<ResponseModel>{
    console.log(user);

    return this.httpClient.post<ResponseModel>(this.apiUrl+'users/updateprofile',{
      user:{
        'id':user.id,
        'firstName':user.firstName,
        'lastName':user.lastName,
        'email':user.email,
        'status':user.status
      },
      password:user.password
    });
  }


  fakeIndeks(faleIndeksModel:FakeFIndeksModel ):Observable<SingleResponseModel<FakeFIndeksModel>>{
    return this.httpClient.post<SingleResponseModel<FakeFIndeksModel>>(this.apiUrl+'users/getuserfindeks',faleIndeksModel);

  }




}
