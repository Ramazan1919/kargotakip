using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class ShipmentPackageDto
    {
        public int Weight { get; set; }
        public ShipSize Size { get; set; }
        public bool isPet { get; set; }
        public bool isLiquid { get; set; }
        public bool isDanger { get; set; }
    }
}
