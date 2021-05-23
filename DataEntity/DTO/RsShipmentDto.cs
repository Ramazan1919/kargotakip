using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class RsShipmentDto
    {
        
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }

        public int Weight { get; set; }
        public ShipSize Size { get; set; }

        public decimal Price { get; set; }
      

    }
}
