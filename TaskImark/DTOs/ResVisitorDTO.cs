using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.DTOs
{
    public class ResVisitorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Remarks { get; set; }
        public int ManagerId { get; set; }
        public DateOnly Date { get; set; }
    }
}
