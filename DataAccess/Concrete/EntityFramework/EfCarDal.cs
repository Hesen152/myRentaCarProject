using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
    

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.Id
                            
                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             select new CarDetailDto
                             { id=car.Id,
                             brandId=brand.Id,
                                 CarName = car.Name,
                                 BrandName=brand.Name,
                                 ColorName = color.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath=car.CarImagess.FirstOrDefault(c=>c.IsMain).ImagePath
                                 //CarImages=context.CarImages.Where(img=>img.CarId==car.Id && img.IsMain).ToList()
                           
                             };

                return result.ToList();



            }


        }

        public CarForDetailDto GetForDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (var context=new RentaCarContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join image in context.CarImages
                             on car.Id equals image.CarId
                             select new CarForDetailDto()
                             {
                                 Id = car.Id,
                                 CarName = car.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 CarImages = car.CarImagess,
                                 

                             };

                return result.AsNoTracking().FirstOrDefault();
            }
        }


    
       

    }

 
    
}
