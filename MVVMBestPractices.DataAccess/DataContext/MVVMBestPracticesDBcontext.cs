using Microsoft.EntityFrameworkCore;
using MVVMBestPractices.Domain.Entities;
using System;

namespace MVVMBestPractices.DataAccess.DataContext
{
    public class MVVMBestPracticesDBcontext : DataContextBase, IMVVMBestPracticesDBcontext
    {
        public MVVMBestPracticesDBcontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ActivityEntity> Activity { get; set; }
        public DbSet<EquipmentEntity> Equipment { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
