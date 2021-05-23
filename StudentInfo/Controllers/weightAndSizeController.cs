using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class weightAndSizeController : ControllerBase
    {
        private IWeightAndSizeServices _weightAndSizeServices;
        public weightAndSizeController(IWeightAndSizeServices weightAndSizeServices)
        {
            _weightAndSizeServices = weightAndSizeServices;
        }
        // GET: api/<weightAndSizeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<weightAndSizeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
           {
                if (id > 0)
                {
                    var model = _weightAndSizeServices.Get(id);
                    return Ok(model);
                }

                        }
                        catch (Exception ex)
                        {
                            // return ex.Message;
                       }

                      return BadRequest();
            }

        // POST api/<weightAndSizeController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<weightAndSizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<weightAndSizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
