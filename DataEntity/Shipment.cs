using DataEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Shipment : IEntity
    {
        public int Id { get; set; }
        public int ShippmentPackageId { get; set; }
        public string TrackingId { get; set; }

        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string ShippingNote { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }

       // public  map<string, bool> ShipProperties { get; set; }

        public int  Remaining { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public decimal Price { get; set; }

        public string RemainingTime { get; set; }





        public ShippmentPackage ShippmentPackage { get; set; }
    }
}
