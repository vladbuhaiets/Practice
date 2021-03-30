using System.ComponentModel.DataAnnotations;
namespace CRUD_Airport.Models
{ 
    public class Pilot
    {
        [Key]
        public int Pilot_ID { get; set; }

        public int? AccesibleModels_ID { get; set; }
    }
}