using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Airport.Models;
namespace CRUD_Airport.Controllers
{

    [Route("api/Airplanes")]

    public class AirplanesController : ControllerBase
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("fFindall")]
        public async Task<IActionResult> Findall()
        {
            try
            {
                var airplanes = db.Airplanes.ToList();
                return Ok(airplanes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var airplanes = db.Airplanes.Find(id);
                return Ok(airplanes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Airplanes airplane)
        {
            try
            {
                db.Airplanes.Add(airplane);
                db.SaveChanges();
                return Ok(airplane);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Airplanes airplane)
        {
            try
            {
                db.Entry(airplane).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(airplane);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Airplanes.Remove(db.Airplanes.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
