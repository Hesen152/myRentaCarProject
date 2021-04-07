import { CustomerComponent } from './components/customer/customer.component';
import { BrandComponent } from './components/brand/brand.component';
import { CarComponent } from './components/car/car.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardetailComponent } from './components/car/cardetail/cardetail.component';
import { RentalComponent } from './components/rental/rental.component';
import { CardComponent } from './components/card/card.component';
import { CarAddComponent } from './components/car-add/car-add.component';

const routes: Routes = [
 {path:"",pathMatch:"full",component:CarComponent},
 {path:"brands",component:BrandComponent},
 {path:'cards',component:CardComponent},
 {path:"customers",component:CustomerComponent},
 {path:"rentals",component:RentalComponent},
 {path:"cars/details/:carId", component:CardetailComponent},

 {path:'cars',children:[
  {path:'',component:CarComponent},
  {path:'filter/:brandId',component:CarComponent},
  {path:'add',component:CarAddComponent}
    // {path:"details/:carId", component:CardetailComponent}

 ]
},


//  {path:"cars",component:CarComponent},

  {path:"cars/brand/:brandId",component:CarComponent},




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
