using BusinessLayer.Abstract;
using DataEntity;
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
        public ShippmentController(IShippmentServices shippmentServices)
        {
            _shippmentServices = shippmentServices;
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Add([FromBody] Shipment shipment)
        {
            shipment.TrackingId = ShortId.Generate(true, false, 11);
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _shippmentServices.Add(shipment);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                // return ex.Message;
            }



            return BadRequest();
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
    }
}
