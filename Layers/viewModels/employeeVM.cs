using Layers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Layers.viewModels
{
    public class employeeVM
    {
        [Key]
        public int SSN { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Minit { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }

        [Column(TypeName = "money")]
        public int? Salary { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public int? SupervisorSSN { get; set; }
        public SelectList? Supervisors { get; set; }
    }
}
