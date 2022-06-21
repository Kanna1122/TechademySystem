using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademySystem.Models;

namespace TechademySystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TechademySystem.Models.Designation> Designation { get; set; }
        public DbSet<TechademySystem.Models.Employee> Employee { get; set; }
        public DbSet<TechademySystem.Models.Leave> Leave { get; set; }
        public DbSet<TechademySystem.Models.PaymentRule> PaymentRule { get; set; }
        public DbSet<TechademySystem.Models.User> User { get; set; }
        public DbSet<TechademySystem.Models.WorkingHours> WorkingHours { get; set; }
        
    }
}
