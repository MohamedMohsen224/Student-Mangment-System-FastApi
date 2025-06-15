using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;

namespace TrialDay.Repo.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<Mark> marks { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }

       
    }
}
