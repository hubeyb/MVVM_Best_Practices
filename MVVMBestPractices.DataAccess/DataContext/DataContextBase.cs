using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVVMBestPractices.DataAccess.DataContext
{
    public class DataContextBase : DbContext
    {
        public DataContextBase(DbContextOptions options) : base(options)
        {
        }
    }
}
