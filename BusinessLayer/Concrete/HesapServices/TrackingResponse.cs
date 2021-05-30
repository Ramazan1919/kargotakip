using BusinessLayer.Abstract;
using DataEntity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete.HesapServices
{
    public class TrackingResponse
    {

        IShippmentServices _shippmentServices;
        public TrackingResponse(IShippmentServices shippmentServices)
        {
            _shippmentServices = shippmentServices;
        }

        public RsShipmentWithTrackIdDto getShipment(String trackingId)
        {
            var res= _shippmentServices.GetFilter(x => x.TrackingId == trackingId, "ShippmentPackage");
            var asd = new RsShipmentPackageDto
            {
                Size=res.ShippmentPackage.Size,
                Weight=res.ShippmentPackage.Weight
            };
            var resmodel = new RsShipmentWithTrackIdDto
            {
                DepartureDate=res.DepartureDate,
                EstimatedArrivalDate=res.EstimatedArrivalDate,
                RecieverAddress=res.ReceiverAddress,
                SenderAddress=res.SenderAddress,
                shipmentPackage= asd,
                TrackId =res.TrackingId
                



            };
            return resmodel;

        }

    }
}
