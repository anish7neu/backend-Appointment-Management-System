using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskImark.Models
{
    public class Visitor
    {
        
         
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Remarks { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public DateOnly Date { get; set; }    
        
    }
}
