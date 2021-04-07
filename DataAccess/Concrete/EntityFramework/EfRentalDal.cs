using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentaCarContext>, IRentalDal
    {
       

        public List<RentalDetailDto> GetRentalDetails()
        {

            using (RentaCarContext context = new RentaCarContext())
            {


                var result =

                             from rental in context.Rentals
                             join car in context.Cars    on rental.CarId equals car.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id

                             join brand in context.Brands    on car.BrandId equals brand.Id

                             select new RentalDetailDto
                             {
                                 BrandName = brand.Name,
                                 CustomerFullName = user.FirstName +""+ user.LastName,
                                 CustomerCompanyName = customer.CompanyName,
                                 Description = car.Description,
                                 RentalId = rental.Id,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate


                             };
             return result.ToList();



            }


        }



    }
}
