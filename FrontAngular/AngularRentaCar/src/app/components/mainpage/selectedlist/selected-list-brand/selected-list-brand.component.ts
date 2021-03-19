import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-selected-list-brand',
  templateUrl: './selected-list-brand.component.html',
  styleUrls: ['./selected-list-brand.component.css']
})
export class SelectedListBrandComponent implements OnInit {

  brands:Brand[]=[];
  currentBrand:Brand;


  constructor(private brandService:BrandService) { this.getBrands(); }

  ngOnInit(): void {
    this.getBrands();
  }


  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    })
}


 FilterValue(brand:Brand){
   this.currentBrand=brand;
     console.log(this.currentBrand);
 }




}
