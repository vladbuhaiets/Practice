using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Airport.Controllers;

namespace CRUD_Airport.Models
{
    public abstract class CRUDops:ControllerBase
    {

        public abstract Task<IActionResult> Findall();
        public abstract Task<IActionResult> Find(int id);
       public abstract Task<IActionResult> Create<T>([FromBody]  T type);
        public abstract Task<IActionResult> Update<T>([FromBody] T type); 
        public abstract Task<IActionResult> Delete(int id);
    }

    
    public class Pilot : CRUDops 
    {
        private DataContext db = new DataContext();
        [Key]
        public int Pilot_ID { get; set; }
     
        public int? AccesibleModels_ID { get; set; }

        //Findall
        public override async Task<IActionResult> Findall()
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
        public override async Task<IActionResult> Find(int id)
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
        
        public override async Task<IActionResult> Create<Pilot>([FromBody] Pilot pilotm)
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
        public override async Task<IActionResult> Update<Pilot>([FromBody] Pilot pilot)
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
        public override async Task<IActionResult> Delete(int id) 
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




    public class Stuardess : CRUDops 
    {
        private DataContext db = new DataContext();
        [Key]
        public int Stuardess_ID { get; set; }

        //Findall
        public override async Task<IActionResult> Findall()
        {
            try
            {
                var stuardess = db.Stuardess.ToList();
                return Ok(stuardess);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Find(ID)
        public override async Task<IActionResult> Find(int id)
        {
            try
            {
                var stuardess = db.Stuardess.Find(id);
                return Ok(stuardess);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Create
        public override async Task<IActionResult> Create<Stuardess>([FromBody] Stuardess stuardess)
        {
            
            try
            {
                db.Stuardess.Add(stuardess);
                db.SaveChanges();
                return Ok(stuardess);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Update
        public override async Task<IActionResult> Update<Stuardess>([FromBody] Stuardess stuardess)
        {
            try
            {
                db.Entry(stuardess).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(stuardess);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Delete 
        public override async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Stuardess.Remove(db.Stuardess.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }



    public class Airplanes
    {

        [Key]
        public int Airplanes_ID { get; set; }
        public int Board_number { get; set; }

        public string Model { get; set; }

        public int? Working_hours { get; set; }

       
    }
}
