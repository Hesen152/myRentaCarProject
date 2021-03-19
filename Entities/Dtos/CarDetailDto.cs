using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class CarDetailDto:IDto
    {

        public int id { get; set; }

        public int brandId { get; set; }

        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }

        public List < CarImages> CarImages { get; set; }
        public string ImagePath { get; set; }
    }
}
