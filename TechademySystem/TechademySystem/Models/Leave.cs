using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademySystem.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Task { get; set; }
        [Required]
        public DateTime When { get; set; }
        [StringLength(200)]
        [Required]
        public string Reason { get; set; }
        [Required]
        [StringLength(20)]
        public string EmployeeId { get; set; }

    }
}
