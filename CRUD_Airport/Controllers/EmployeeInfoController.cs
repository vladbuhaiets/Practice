using CRUD_Airport.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Airport.Controllers
{
    [Route("api/EmpoyeeInfo")]
    public class EmpoyeeInfoController : ControllerBase
    {
        private DataContext db = new DataContext();


        //Findall
        [Produces("application/json")]
        [HttpGet("Findall")]
        public async Task<IActionResult> Findall()
        {
            try
            {
                var employee = db.EmployeeInfo.ToList();
                return Ok(employee);
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
                var employee = db.EmployeeInfo.Find(id);
                return Ok(employee);
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
        public async Task<IActionResult> Create([FromBody] EmployeeInfo employee)
        {

            try
            {
                db.EmployeeInfo.Add(employee);
                db.SaveChanges();
                return Ok(employee);
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
        public async Task<IActionResult> Update([FromBody] EmployeeInfo employee)
        {
            try
            {
                db.Entry(employee).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Delete 
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.EmployeeInfo.Remove(db.EmployeeInfo.Find(id));
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