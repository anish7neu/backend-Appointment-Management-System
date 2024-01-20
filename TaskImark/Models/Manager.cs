using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.Models
{
    public class Manager
    {
        
        public int Id { get; set; }
        [StringLength(30)]
        public required string FirstName { get; set; }
        [StringLength(30)]
        public required string LastName { get; set; }
        [StringLength(30)]
        public required string Address { get; set; }
        [StringLength(10)]
        public required string Phone { get; set; }
        [StringLength(6)]
        public required string Gender { get; set; }
    }
}
