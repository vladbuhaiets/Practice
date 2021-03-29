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
        [HttpGet("Findall")]
        public async Task<IActionResult> Findall()   // Read all Airplanes
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
        public async Task<IActionResult> Find(int id)   // Read(ID) Airplane
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
        public async Task<IActionResult> Create([FromBody] Airplanes airplane) // Create new Airplane
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
        public async Task<IActionResult> Update([FromBody] Airplanes airplane)  // Update info Airplane
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
        public async Task<IActionResult> Delete(int id)    // Delete(ID) Airplane
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


        // Example one of CRUDs  for Pilots
        //[Produces("application/json")]
        //[HttpGet("Findall/Pilot")]
        // Here must be a function like:    Pilot.Findall();
    }
}