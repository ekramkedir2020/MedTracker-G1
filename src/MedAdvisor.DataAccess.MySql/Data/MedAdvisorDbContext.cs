/**global using Microsoft.EntityFrameworkCore;
using MedAdvisor.DataAccess.Mysql;
using MedAdvisor.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAdvisor.DataAccess.MySql
{
    public class MedAdvisorDbContext : DbContext
    {
        public MedAdvisorDbContext(DbContextOptions<MedAdvisorDbContext> options) : base(options) 
        {
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<UserRegister> UserRegisters { get; set; }  
    }
}
*/