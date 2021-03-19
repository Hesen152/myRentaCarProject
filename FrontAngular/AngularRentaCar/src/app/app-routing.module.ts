import { CustomerComponent } from './components/customer/customer.component';
import { BrandComponent } from './components/brand/brand.component';
import { CarComponent } from './components/car/car.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardetailComponent } from './components/car/cardetail/cardetail.component';
import { RentalComponent } from './components/rental/rental.component';

const routes: Routes = [
 {path:"",pathMatch:"full",component:CarComponent},
 {path:"cars",component:CarComponent},
 {path:"brands",component:BrandComponent},
 {path:"customers",component:CustomerComponent},
 {path:"rentals",component:RentalComponent},
  {path:"cars/brand/:brandId",component:CarComponent},
  {path:"cars/details/:carId", component:CardetailComponent}




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
