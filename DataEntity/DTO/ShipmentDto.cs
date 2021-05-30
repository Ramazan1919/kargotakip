using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class ShipmentDto
    {
        public string title { get; set; }
        public string shippingNote { get; set; }
        public string senderAddress { get; set; }
        public string receiverAddress { get; set; }

        public ShipmentPackageDto ShipmentPackageDto { get; set; }

        
    }
}
