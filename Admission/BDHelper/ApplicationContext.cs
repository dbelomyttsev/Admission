using Admission.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admission.BDHelper
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Abiturient> Abiturients { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<AbiturientDirection> AbiturientDirections { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AdmissionDB;Username=postgres;Password=123098");
        }
    }
}
