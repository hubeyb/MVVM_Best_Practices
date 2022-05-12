using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.DataAccess.DataContext
{
    public class MockDBContext
    {
        public static MVVMBestPracticesDBcontext GetMockDBContext()
        {
            var options = new DbContextOptionsBuilder<MVVMBestPracticesDBcontext>()
                                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                    .Options;

            var databaseContext = new MVVMBestPracticesDBcontext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}
