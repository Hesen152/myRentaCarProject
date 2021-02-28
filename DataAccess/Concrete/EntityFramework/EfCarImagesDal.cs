using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImages, RentaCarContext>, ICarImagesDal
    {
    
    }
}
