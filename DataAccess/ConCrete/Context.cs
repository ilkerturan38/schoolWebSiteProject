using Entity;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete
{
    public class Context:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Lesson> lesson { get; set; }
        public DbSet<Episode> episode { get; set; }
        public DbSet<Notes> notes { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<StudentvsTeacher> StudentvsTeacher { get; set; }
    }
}
