using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public Brand()
        {
            this.Cars = new List<Car>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Car> Cars { get; set; }
    }
}
