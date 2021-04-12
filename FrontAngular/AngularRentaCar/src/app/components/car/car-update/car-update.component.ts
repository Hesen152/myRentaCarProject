import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-update',
  templateUrl: './car-update.component.html',
  styleUrls: ['./car-update.component.css']
})
export class CarUpdateComponent implements OnInit {



  carUpdateForm:FormGroup;
  brands:Brand[]=[];
  car:Car;



  constructor(private carService:CarService,
        private formBuilder:FormBuilder,
        private brandService:BrandService,
         private toastService:ToastrService,
        private  activatedRoute:ActivatedRoute,


    ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(param=>{
      this.getCarById(param['carId'])
    })

  }
    getCarById(carId:number){
      this.carService.getCarById(carId).subscribe(response=>{
        this.car==response.data;

        this.getBrands();
      })
    }


    getBrands(){
      this.brandService.getBrands().subscribe(response=>{
        this.brands==response.data;
      })
    }



  carUpdateFormMethod(){
    this.carUpdateForm=this.formBuilder.group({
      id:[this.car.id,Validators.required],
      brandId:[this.car.brandId,Validators.required],
      dailyPrice:[this.car.dailyPrice,Validators.required],
      modelYear:[this.car.modelYear,Validators.required],
      description:[this.car.brandId,Validators.required]

    })
  }


  update(){
    let car:Car=Object.assign({},this.carUpdateForm.value);


    car.brandId=Number(car.brandId)

    if (!this.carUpdateForm.valid) {
      this.toastService.warning('Lütfen boş bilgi bırakmayın', 'Dikkat');
      return;
   }

   this.carService.updateCar(car).subscribe(response => {
      return this.toastService.success(response.message, 'Başarılı');
   }, responseError => {
      if (responseError.error.ValidationErrors.length == 0) {
         this.toastService.error(responseError.error.Message, responseError.error.StatusCode);
         return;
      }

      for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
         this.toastService.error(
            responseError.error.ValidationErrors[i].ErrorMessage, 'Doğrulama Hatası'
         );
      }
   });
  }

}
