using DataEntity.Abstract;
using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class ShippmentPackage:IEntity
    {
        public int Id { get; set; }

        public int Weight { get; set; }
        public ShipSize Size { get; set; }
        public bool isPet { get; set; }
        public bool isLiquid { get; set; }
        public bool isDanger { get; set; }



    }
}
