using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //RentalTest();
            //CarTest();

            //var carImagesAttribute = typeof(CarImages).GetProperty("Image").GetCustomAttributes().Select(a => a.GetType());
            //Console.WriteLine(carImagesAttribute.First().Name);
            //int a = 2;
            //long b = 15;


            //Type type = b.GetType();

            //Console.WriteLine(type);

            // var result=Object.ReferenceEquals(a.GetType(), b.GetType());


            ////Console.WriteLine($"x and b is same thype {result} ");
            //#region Reflector
            //Assembly info = typeof(int).Assembly;

            //Console.WriteLine(info);
            //SqlConnection connection = new SqlConnection();


            //#endregion



           // CarrTest();

            //            string connectionString=(@"Server=(localdb)\MSSQLLocalDB;
            //Database=CarRentalDb;Trusted_Connection=True");

            //            string queryString = "Select BrandId,ColorId,DailyPrice from dbo.Cars "
            //                +"Where DailyPrice >@pricePoint";
            //            int paramValue = 5;

            //            using (SqlConnection connection=new SqlConnection(connectionString))
            //            {
            //                SqlCommand command = new SqlCommand(queryString, connection);
            //                command.Parameters.AddWithValue("@pricePoint", paramValue);


            //                try
            //                {
            //                    connection.Open();
            //                    SqlDataReader reader = command.ExecuteReader();

            //                    while (reader.Read())
            //                    {
            //                        Console.WriteLine($"{reader[0]} +{reader[1] }+{reader[2]}");


            //                    }
            //                    reader.Close();
            //                }
            //                catch (Exception ex)
            //                {

            //                    Console.WriteLine(ex.Message);
            //                }



            //            }

    





        }

        //private static void CarrTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();
        //    if (result.Success)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.Car + "/" + car.BrandName);
        //        }

        //    }

        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}




        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now });

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Name = "Wolsvagen Passat", BrandId = 1, ColorId = 1, DailyPrice = 2300, ModelYear = 2015, Description = "Good automobile" });
            carManager.Add(new Car { Name = "Mercedes XX12", BrandId = 2, ColorId = 2, DailyPrice = 1500, ModelYear = 2007, Description = "one of the best brands of mercedes" });


            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);

            }

        }




    }
}
