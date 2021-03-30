using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Airport.Controllers;

namespace CRUD_Airport.Models
{

    public class Airplanes
    {

        [Key]
        public int Airplanes_ID { get; set; }
        public int? Board_number { get; set; }

        public string Model { get; set; }

        public int? Working_hours { get; set; }

       
    }
}
