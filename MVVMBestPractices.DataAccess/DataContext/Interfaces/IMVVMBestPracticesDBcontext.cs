using Microsoft.EntityFrameworkCore;
using MVVMBestPractices.Domain.Entities;
using System;

namespace MVVMBestPractices.DataAccess.DataContext
{
    public interface IMVVMBestPracticesDBcontext
    {
        DbSet<ActivityEntity> Activity { get; set; }
        DbSet<EquipmentEntity> Equipment { get; set; }

        int SaveChanges();
    }
}
