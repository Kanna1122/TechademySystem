using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademySystem.Models
{
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; }
        [StringLength(50)]
        [Required]
        public string RollName { get; set; }
        [StringLength(50)]
        [Required]
        public string DepartmentName { get; set; }
    }
}
