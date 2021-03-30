using CRUD_Airport.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Airport.Controllers
{
    [Route("api/Stewardess")]
    public class StewardessController : ControllerBase
    {
        private DataContext db = new DataContext();


        //Findall
        [Produces("application/json")]
        [HttpGet("Findall")]
        public async Task<IActionResult> Findall()
        {
                try
                {
                    var stewardess = db.Stewardess.ToList();
                    return Ok(stewardess);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
        }

        //Find(ID)
        [Produces("application/json")]
        [HttpGet("Find/{id}")]
        public  async Task<IActionResult> Find(int id)
            {
                try
                {
                    var stewardess = db.Stewardess.Find(id);
                    return Ok(stewardess);
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
        public  async Task<IActionResult> Create([FromBody] Stewardess stewardess)
            {

                try
                {
                    db.Stewardess.Add(stewardess);
                    db.SaveChanges();
                    return Ok(stewardess);
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
        public  async Task<IActionResult> Update([FromBody] Stewardess stewardess)
            {
                try
                {
                    db.Entry(stewardess).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return Ok(stewardess);
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
                    db.Stewardess.Remove(db.Stewardess.Find(id));
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