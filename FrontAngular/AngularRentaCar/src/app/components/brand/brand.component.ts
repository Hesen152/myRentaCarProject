import { BrandService } from './../../services/brand.service';
import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {

   brands:Brand[]=[];
  currentBrand:Brand={id:0,name:""};




  constructor(private  brandService:BrandService) { }

  ngOnInit(): void {

   this.getBrands();
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    })


  }

   setCurrentBrand(brand:Brand){
     this.currentBrand=brand;
   }

   getCurrentBrandClass(brand:Brand){
    if (brand==this.currentBrand) {
       return  "list-group-item active"
    }
    else{
       return "list-group-item"
    }
  }

  getAllBrandClass(){
    if (this.currentBrand.name.length<1) {
      return "list-group-item active"
    }
    else{
      return "list-group-item"
    }
  }
  removeCurrentBrand(){
    return  this.currentBrand={id:0,name:""};
   }

}
