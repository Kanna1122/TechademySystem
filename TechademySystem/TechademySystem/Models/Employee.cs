using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademySystem.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string EmployeeId { get; set; }
        [StringLength(50)]
        [Required]
        public string EmployeeName { get; set; }
        [StringLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        [Required]
        public string EmailId { get; set; }
        [StringLength(200)]
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; }


    }
}
