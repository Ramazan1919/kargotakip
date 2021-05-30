using BusinessLayer.Concrete.HesapServices;
using DataEntity.DTO;
using DataEntity.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoEstimatedController : ControllerBase
    {
        private readonly ShippingCalculator _cargoCashCalculate;
        public CargoEstimatedController(ShippingCalculator cargoCashCalculate)
        {
            _cargoCashCalculate = cargoCashCalculate;
        }

        [HttpPost]
        public IActionResult CargoEstimate(RsEstimateShipmentDto rsShipmentDto)
               {
          
                   var result=  _cargoCashCalculate.CalculateShip(rsShipmentDto.SenderAddress,rsShipmentDto.ReceiverAddress,rsShipmentDto.Weight,rsShipmentDto.Size);

                    return Ok(result);




               }
    }
}
