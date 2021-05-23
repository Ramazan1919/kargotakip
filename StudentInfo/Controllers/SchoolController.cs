//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BusinessLayer.Abstract;
//using DataEntity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace StudentInfo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SchoolController : ControllerBase
//    {

//        private readonly ISchoolService _schoolService;
//        public SchoolController(ISchoolService schoolService)
//        {
//            _schoolService = schoolService;
//        }

//        // GET: api/Students
//        [HttpGet("all")]
//        public List<School> GetAll()
//        {
//            return _schoolService.GetAll();
//        }

//        // GET: api/Students/5
//        [HttpGet("{id}")]
//        public ActionResult Get(int id)
//        {
//            try
//            {
//                if (id > 0)
//                {
//                    var model = _schoolService.Get(id);
//                    return Ok(model);
//                }

//            }
//            catch (Exception ex)
//            {
//                // return ex.Message;
//            }

//            return BadRequest();

//        }



//        [HttpPost]
//        public ActionResult Add([FromBody] School school)
//        {

//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var result = _schoolService.Add(school);
//                    return Ok(result);
//                }

//            }
//            catch (Exception ex)
//            {
//                // return ex.Message;
//            }



//            return BadRequest();
//        }





//        [HttpPut]
//        public ActionResult Update(School school)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var record = _schoolService.Get(school.Id);
//                    if (record == null)
//                    {
//                        return NotFound();

//                    }
//                    else
//                    {
//                        record.Name = school.Name;
//                        record.Address = school.Address;
//                        record.Popularity = school.Popularity;




//                        _schoolService.Update(record);

//                        return Ok(record);
//                    }



//                }
//                else
//                {

//                    return NotFound();


//                }

//            }
//            catch (Exception ex)
//            {

//            }
//            return BadRequest();

//        }



//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                if (id > 0)
//                {

//                    var delItem = _schoolService.Delete(id);
//                    return Ok(delItem);
//                }
//            }
//            catch (Exception ex)
//            {
//                //Logging
//            }

//            return NotFound();
//        }

//    }
//}