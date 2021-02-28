using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
   public  class Car:IEntity
    {
        public Car()
        {
            this.Colors = new List<Color>();
            this.CarImagess = new List<CarImages>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public short ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        //addition for
        public Brand Brand { get; set; }
        public List<Color> Colors { get; set; }

        public List<CarImages> CarImagess { get; set; }

    }
}
