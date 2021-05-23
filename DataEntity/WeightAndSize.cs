using DataEntity.Abstract;
using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class WeightAndSize : IEntity
    {
        public int Id { get; set; }

        public  int WeightMin { get; set; }
        public  int WeightMax { get; set; }
        public ShipSize Size { get; set; }

        public decimal Price { get; set; }

    }
}
