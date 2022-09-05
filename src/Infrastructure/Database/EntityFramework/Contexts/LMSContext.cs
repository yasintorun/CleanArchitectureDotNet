using LMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LMS.Infrastructure.Database.EntityFramework.Contexts
{
    internal class LMSContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public LMSContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
