using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {



           
        }





        //private static  void RentalTest()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());

        //    rentalManager.Add(new Rental { CartId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now });

        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car {Name="Wolsvagen Passat",BrandId=1,ColorId=1,DailyPrice=2300,ModelYear=2015,Description="Good automobile"});
        //    carManager.Add(new Car { Name = "Mercedes XX12", BrandId = 2, ColorId = 2, DailyPrice = 1500, ModelYear = 2007, Description = "one of the best brands of mercedes" });


        //    foreach (var car in  carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.Name); 

        //    }

        //}

    }
}
