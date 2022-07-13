using CleanArchitecture.Domain.Models;
using Infrastructure.Database.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Database.EFCore.Contexts
{
    public class ProjectContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMapping());
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
