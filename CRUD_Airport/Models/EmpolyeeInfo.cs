using System.ComponentModel.DataAnnotations;
namespace CRUD_Airport.Models
{
    public class EmployeeInfo
    {

        private DataContext db = new DataContext();
        [Key]
        public int EmployeesInfo_ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Grade { get; set; }
        public int? Experience { get; set; }
        public string Birthdate { get; set; }
        public string Address_Employee { get; set; }
    }
}