using BusinessLayer.Concrete.HesapServices;
using DataEntity.DTO;
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
        private readonly CargoCashCalculate _cargoCashCalculate;
        public CargoEstimatedController(CargoCashCalculate cargoCashCalculate)
        {
            _cargoCashCalculate = cargoCashCalculate;
        }

        [HttpPost("cargoEstimated")]
               public IActionResult CargoEstimate(RsShipmentDto rsShipmentDto)
               {
                   var result=  _cargoCashCalculate.CalculateShipp(rsShipmentDto.SenderAddress,rsShipmentDto.ReceiverAddress,rsShipmentDto.Weight,rsShipmentDto.Size);

            return Ok(result);
               }
    }
}
