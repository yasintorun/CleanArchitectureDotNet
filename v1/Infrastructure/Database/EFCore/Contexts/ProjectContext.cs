using CleanArchitecture.Domain.Models;
using Infrastructure.Database.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database.EFCore.Contexts
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=CleanArchitecture_LMS; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMapping());
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
