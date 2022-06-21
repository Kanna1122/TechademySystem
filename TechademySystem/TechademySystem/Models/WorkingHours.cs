using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademySystem.Models
{
    public class WorkingHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string EmployeeWorkingHours { get; set; }
        [Required]
        [StringLength(20)]
        public string EmployeeId { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}
