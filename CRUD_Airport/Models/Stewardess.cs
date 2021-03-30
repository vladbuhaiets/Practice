using System.ComponentModel.DataAnnotations;
namespace CRUD_Airport.Models
{
    public class Stewardess
    {

        private DataContext db = new DataContext();
        [Key]
        public int Stewardess_ID { get; set; }
    }
}