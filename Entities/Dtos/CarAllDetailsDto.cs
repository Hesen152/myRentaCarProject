using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
  public  class CarAllDetailsDto:IDto
    {
        public int CarId { get; set; }

        public string CarName { get; set; }

        public string BrandName { get; set; }

        public string ColorName { get; set; }

        public string CarImages { get; set; }

        public int DailyPrice { get; set; }
    }
}
