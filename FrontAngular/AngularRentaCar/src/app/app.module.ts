import { NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
 import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { BrandComponent } from './components/brand/brand.component';
import { NaviComponent } from './components/mainpage/navi/navi.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CarComponent } from './components/car/car.component';
import { RentalComponent } from './components/rental/rental.component';
import { CardetailComponent } from './components/car/cardetail/cardetail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BodyComponent } from './components/mainpage/body/body.component';
import { FooterComponent } from './components/mainpage/footer/footer.component';
import { HeaderComponent } from './components/mainpage/header/header.component';
import { CarfilterPipePipe } from './pipes/carfilter-pipe.pipe';
import { SelectedListBrandComponent } from './components/mainpage/selectedlist/selected-list-brand/selected-list-brand.component';

@NgModule({
  declarations: [
    AppComponent,
    BrandComponent,
    NaviComponent,
    CustomerComponent,
    CarComponent,
    RentalComponent,
    CardetailComponent,
    BodyComponent,
    FooterComponent,
    HeaderComponent,
    CarfilterPipePipe,
    SelectedListBrandComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
