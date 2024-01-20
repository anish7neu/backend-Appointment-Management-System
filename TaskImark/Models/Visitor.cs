using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        [StringLength(30)]
        public required string FirstName { get; set; }
        [StringLength(30)]
        public required string LastName { get; set; }
        [StringLength(30)]
        public required string Address { get; set; }
        [StringLength(50)]
        public required string Phone { get; set; }
        [StringLength(6)]
        public required string Gender { get; set; }
        [StringLength(200)]
        public string? Remarks { get; set; }
        public required int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public required DateOnly Date { get; set; } 
    }
}
