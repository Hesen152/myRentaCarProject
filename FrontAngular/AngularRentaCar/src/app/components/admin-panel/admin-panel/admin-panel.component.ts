import { Car } from 'src/app/models/car';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';
import { CarService } from 'src/app/services/car.service';
import { CustomerService } from 'src/app/services/customer.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { RentalService } from 'src/app/services/rental.service';
import { UserserviceService } from 'src/app/services/userservice.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {


  user:User = new User();
  totalCar:string
  totalRentedCar:string
  totalCustomer:string
  lastRentedCar:Car = new Car();

  constructor(private carService: CarService,
    private rentalService: RentalService,
    private customerService: CustomerService,
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private userService: UserserviceService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    if (this.localStorageService.get('yetki')) {
      this.load();
    } else {
      this.router.navigate(['/'])
      this.toastrService.warning('you are not authorized')
    }
  }

  load() {
    this.getEmail();
    this.getTotalCars();
    this.getTotalRentedCar();
    this.getTotalCustomers();
    this.getLastRentedCar()
  }

  getEmail() {
    this.userService.getByEmail(this.localStorageService.get('email')).subscribe(response => {
      this.user = response;
    })
  }

  getTotalCars() {
    this.carService.getTotalCars().subscribe(response => {
      this.totalCar = response.data.toString()
    })
  }

  getTotalRentedCar() {
    this.rentalService.getTotalRentedCar().subscribe(response => {
      this.totalRentedCar = response.data.toString();
    })
  }

  getTotalCustomers() {
    this.customerService.getTotalCustomers().subscribe(response => {
      this.totalCustomer = response.data.toString();
    })
  }

  getLastRentedCar() {
    this.carService.getLastRentedCar().subscribe(response => {
      this.lastRentedCar = response.data;
    })
  }

}
