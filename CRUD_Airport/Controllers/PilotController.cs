using CRUD_Airport.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Airport.Controllers
{
    [Route("api/Pilot")]
    public class PilotController : ControllerBase
    {
        private DataContext db = new DataContext();


        //Findall
        [Produces("application/json")]
        [HttpGet("Findall")]
        public  async Task<IActionResult> Findall()
        {
            try
            {
                var pilot = db.Pilot.ToList();
                return Ok(pilot);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Find(ID)
        [Produces("application/json")]
        [HttpGet("Find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var pilot = db.Pilot.Find(id);
                return Ok(pilot);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public  async Task<IActionResult> Create([FromBody] Pilot pilotm)
        {
            try
            {
                db.Pilot.Add(pilotm);
                db.SaveChanges();
                return Ok(pilotm);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Update
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Pilot pilot)
        {
            try
            {
                db.Entry(pilot).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(pilot);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Delete 
        [HttpDelete("delete/{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Pilot.Remove(db.Pilot.Find(id));
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