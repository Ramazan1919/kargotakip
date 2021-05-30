using BusinessLayer.Abstract;
using BusinessLayer.Concrete.HesapServices;
using DataEntity;
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
    public class ShipmentPackageController : ControllerBase
    {
        private readonly IShippmentPackageServices _shippmentPackageServices;
        public ShipmentPackageController(IShippmentPackageServices shippmentPackageServices)
        {
            _shippmentPackageServices = shippmentPackageServices;
        }


        [HttpPost]
        public ActionResult Add([FromBody] ShippmentPackage shippmentPackage)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    var valid = Validator.ValidateCargo(shippmentPackage.isPet, shippmentPackage.isLiquid, shippmentPackage.isDanger);
                    if (valid.IsSuccess)
                    {
                        var result = _shippmentPackageServices.Add(shippmentPackage);
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound(valid);
                    }

                    
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
