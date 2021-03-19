using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class CarForDetailDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }

        public CarImages CarImage { get; set; }
        public List<CarImages> CarImages { get; set; }
    }
}
