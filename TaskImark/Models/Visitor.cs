using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.Models
{
    public class Visitor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int VisitorId { get; set; }

        [StringLength(50)]
        [Required]
        public  string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public  string LastName { get; set; }

        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [StringLength(10)]
        [Required]
        public string Phone { get; set; }

        [StringLength(10)]
        [Required]
        public string Gender { get; set; }

        [StringLength(200)]
        [Required]
        public string? Remarks { get; set; }

        [ForeignKey("Manager")]
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public required DateOnly Date { get; set; }    
        
    }
}
