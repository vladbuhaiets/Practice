using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Airport.Models
{
    public class Airplanes
    {

        [Key]
        public int ID { get; set; }
        public int board_number { get; set; }

        public string model { get; set; }

        public int? working_hours { get; set; }

       
    }
}
