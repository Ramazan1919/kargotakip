using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class RsShipmentWithTrackIdDto
    {
        public string TrackId { get; set; }
        public string SenderAddress { get; set; }
        public string RecieverAddress { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }

        public RsShipmentPackageDto shipmentPackage { get; set; }

    }

    public class RsShipmentPackageDto
        {
        public int Weight { get; set; }
        public int Size { get; set; }
    }

}
