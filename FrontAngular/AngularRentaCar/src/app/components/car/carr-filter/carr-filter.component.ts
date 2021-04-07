import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-carr-filter',
  templateUrl: './carr-filter.component.html',
  styleUrls: ['./carr-filter.component.css']
})
export class CarrFilterComponent implements OnInit {



  brands: Brand[] = [];
  currentBrand: Brand;
  brandFilter: number = 0;


  constructor(private brandService: BrandService,
    private activatedRoute: ActivatedRoute) {  }

  ngOnInit(): void {
    this.brandFilter=Number(this.activatedRoute.snapshot.paramMap.get('brandId'));
    this.getBrands();

  }


  getBrands() {
    this.brandService.getBrands().subscribe(response => {
      this.brands = response.data;
    })
  }


  FilterValue(brand: Brand) {
    this.currentBrand = brand;
  }

  clearFilter(){
    this.brandFilter = 0;
 }
}
