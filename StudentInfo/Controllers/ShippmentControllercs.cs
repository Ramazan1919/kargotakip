using BusinessLayer.Abstract;
using BusinessLayer.Concrete.HesapServices;
using DataEntity;
using DataEntity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shortid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippmentController : ControllerBase
    {
        private IShippmentServices _shippmentServices;
        private IShippmentPackageServices _shippmentPackageServices;
        private readonly ShippingCalculator  _shippingCalculator;
        private TrackingResponse _trackingResponse;

        public ShippmentController(ShippingCalculator shippingCalculator, IShippmentServices shippmentServices, IShippmentPackageServices shippmentPackageServices, TrackingResponse trackingResponse)
        {
            _shippmentServices = shippmentServices;
            _shippmentPackageServices = shippmentPackageServices;
            _trackingResponse = trackingResponse;
            _shippingCalculator = shippingCalculator;
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Add([FromBody] ShipmentDto shipmentDto)
        {

            var valid = Validator.ValidateCargo(shipmentDto.ShipmentPackageDto.isPet, shipmentDto.ShipmentPackageDto.isLiquid, shipmentDto.ShipmentPackageDto.isDanger);

            if (valid.IsSuccess)
            {
                var modelPackage = new ShippmentPackage
                {
                    
                   isPet=shipmentDto.ShipmentPackageDto.isPet,
                   isDanger= shipmentDto.ShipmentPackageDto.isDanger,
                   isLiquid= shipmentDto.ShipmentPackageDto.isLiquid,
                   Weight = shipmentDto.ShipmentPackageDto.Weight,
                   Size = shipmentDto.ShipmentPackageDto.Size,
        
                };
                _shippmentPackageServices.Add(modelPackage);

                


                //shipmentDto.ShippmentPackageId = shipmentDto.ShippmentPackage.Id;
                //shipmentDto.DepartureDate = new DateTime();
                //shipmentDto.EstimatedArrivalDate = new DateTime(); shipmentDto.TrackingId = ShortId.Generate(true, false, 11);// hesaplanan saat gelecek

                

                
                try
                {


                    if (ModelState.IsValid)
                    {
                        var resultPrice = _shippingCalculator.CalculateShip(shipmentDto.senderAddress,shipmentDto.receiverAddress,shipmentDto.ShipmentPackageDto.Weight,shipmentDto.ShipmentPackageDto.Size);
                        var rTime= _shippingCalculator.CalculateTime(resultPrice.Distance);
                        var msg = _shippingCalculator.calculateRemainingTime(rTime);
                        var modelShipment = new Shipment
                        {
                            IsActive = true,
                            ShippmentPackageId = modelPackage.Id,
                            ReceiverAddress = shipmentDto.receiverAddress,
                            Remaining = resultPrice.Distance,
                            SenderAddress = shipmentDto.senderAddress,
                            ShippingNote = shipmentDto.shippingNote,
                            DepartureDate = DateTime.Now,
                            Title = shipmentDto.title,
                            TrackingId = ShortId.Generate(true, false, 11),
                            EstimatedArrivalDate = DateTime.Now.AddHours(rTime),
                            Price = resultPrice.Price/100,
                            RemainingTime= msg
                        };

                        var result = _shippmentServices.Add(modelShipment);
                        result.Message=modelShipment.TrackingId;
                        return Ok(result);
                    }

                }
                catch (Exception ex)
                {
                    return NotFound(ex);
                }

            }

                return NotFound(valid);
        }


        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var model = _shippmentServices.GetFilter(x => x.Id == id, "ShippmentPackage");
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                // return ex.Message;
            }

            return BadRequest();

        }


        [HttpGet("trackId/{id}")]
        public ActionResult GetWithTrackingId(string id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var model = _trackingResponse.getShipment(id);
                    if(model != null)
                        return Ok(model);
                    return NotFound("model null");
                }

            }
            catch (Exception ex)
            {
                // return ex.Message;
            }

            return BadRequest();

        }

    }
}
