using BusinessLayer.Abstract;
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
                    var result = _shippmentPackageServices.Add(shippmentPackage);
                    return Ok(result);
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
