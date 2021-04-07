import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.css']
})
export class CarAddComponent implements OnInit {


  carAddForm:FormGroup;
  brands:Brand[]=[];

  constructor(private formBuilder:FormBuilder,
    private carService:CarService,
    private toastService:ToastrService,
    private brandService:BrandService
    ) { }

  ngOnInit(): void {
  this.createCarAddForm();
  this.getBrands();
  }

 createCarAddForm(){
   this.carAddForm=this.formBuilder.group({
     brandId:["",Validators.required],
     name:["",Validators.required],
     modelYear:["",Validators.required],
     dailyPrice:["",Validators.required],
       description:["",Validators.required]
   })
 }

 getBrands(){
   this.brandService.getBrands().subscribe(response=>{
     this.brands=response.data;

   },errorresponse=>{
     this.toastService.error(errorresponse.message,errorresponse.name);
   })
 }






 add(){
    let carModel:Car=Object.assign({},this.carAddForm.value)


   if (!this.carAddForm.valid) {
    this.toastService.warning('must be not Empty!',"Warning")
    return;
   }




    carModel.brandId=Number(carModel.brandId);
    carModel.modelYear = Number(carModel.modelYear);
    carModel.dailyPrice = Number(carModel.dailyPrice);

    this.carService.addCar(carModel).subscribe(response=>{
         this.carAddForm.reset();
       this.carAddForm.get('brandId').setValue('');

       console.log(response);

      return this.toastService.success(response.message,"succesfull")
    },responseError=>{
     if (responseError.error.ValidationErrors.length>0) {

      for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
        this.toastService.error(responseError.error.ValidationErrors[i].ErrorMessage,"Verification Error"
        )

      }




        return null;

     }

      console.log(responseError);

      this.toastService.error(responseError.error.Message,responseError.error.StatusCode)

    });

 }




}
