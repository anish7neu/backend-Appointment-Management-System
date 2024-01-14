using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.Models
{
    public class Manager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ManagerId { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(100)]
        [Required]
        public required string Address { get; set; }

        [StringLength(10)]
        [Required]
        public string Phone { get; set; }

        [StringLength(10)]
        [Required]
        public string Gender { get; set; }

     


    }
}
