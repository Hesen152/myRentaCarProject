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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail()
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.Id equals brand.Id
                             join color in context.Colors
                             on car.Id equals color.Id
                             select new CarDetailDto
                             {
                                 CartId = car.Id,
                                 CarName = car.Name,
                                 BrandName = brand.Name,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice


                             };

                return result.ToList();

                            


            }





        }
       
    }
}
