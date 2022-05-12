using MVVMBestPractices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.DataAccess
{
    public interface IActivityService
    {
        List<ActivityEntity> GetList(int? page = null, int? take = null, string searchText = null);
        int Create(ActivityEntity entity);
    }
}
