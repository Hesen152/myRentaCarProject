using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalDetailDto:IDto
    {
        public  int RentalId { get; set; }

        public string CustomerCompanyName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }


        public string CustomerFullName { get; set; }
        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

    }
}
