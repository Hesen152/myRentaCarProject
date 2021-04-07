import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Rental } from 'src/app/models/rental';
import {ToastrService } from "ngx-toastr";
import { RentalService } from 'src/app/services/rental.service';
@Component({
  selector: 'app-car-rent',
  templateUrl: './car-rent.component.html',
  styleUrls: ['./car-rent.component.css']
})
export class CarRentComponent implements OnInit {


  rental:Rental;
  carId:number;
  addRentCarForm:FormGroup;
  currentDate:Date=new Date();
  constructor( private activatedRoute:ActivatedRoute,
     private toastService:ToastrService,
    private rentalService:RentalService ,
    private router:Router,
    private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.carId=Number(this.activatedRoute.snapshot.paramMap.get('carId'));
    this.createAddRentCarForm();
  }


 createAddRentCarForm() {
      this.addRentCarForm = this.formBuilder.group({
         carId: [this.carId, Validators.required],
        //  customerId: [this.localStorageService.getCurrentCustomer().id, Validators.required],
         rentDate: ['', [Validators.required]],
         returnDate: ['', Validators.required]
      });
   }

  setRentingCar(){
   if(this.addRentCarForm.invalid){
     this.toastService.warning('Alanlari kontrol ediniz ','Dikkat');
     return false;
   }

   this.rental=this.addRentCarForm.value;
   let rentDate=new Date(this.rental.rentDate);
   let returnDate=new Date(this.rental.returnDate)

   if (rentDate<this.currentDate) {
     this.toastService.warning(
       "Rent Date,bu gunden sonraki bir baxt olmalidir",'Diqqet'
     );

    return false;
   }

   if (returnDate<rentDate || returnDate.getDate()==rentDate.getDate()) {
     this.toastService.warning(
       'Donus Vaxti,kira tarixinden sonraki gunler olmalidir',"Diqqet"
     );
     return false
   }

   this.rentalService.setRentingCar(this.rental);

   this.toastService.success("Odeme sistemine yonlendirilirsiniz");

   return this.router.navigate(['/cards']);




  }


  checkRental(){
    this.rentalService.getRentalByCarId(this.carId).subscribe(response=>{

      if(response.data[0]==null){
        this.setRentingCar();
        return true;
      }

      let lastItem=response.data[response.data.length-1];

      if (lastItem.returnDate==null) {
        return this.toastService.error("bu masin heleki geri teslim edilmeyib");
      }

      let returnDate=new Date(lastItem.returnDate);
      this.setRentingCar();


      if (new Date(this.rental.rentDate)<returnDate) {
        this.rentalService.removeRentingCar();
        return this.toastService.warning(
          "Bu araci bu tarixler arasinda kiralaya bilmezsiniz","Diqqet"
        );

      }


      return true;


    })
  }

}



