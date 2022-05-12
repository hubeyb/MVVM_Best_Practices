using MVVMBestPractices.DataAccess.DataContext;
using MVVMBestPractices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.DataAccess.Services
{
    public class ActivityService : IActivityService
    {
        private IMVVMBestPracticesDBcontext DBcontext;

        public ActivityService(IMVVMBestPracticesDBcontext dBcontext)
        {
            DBcontext = dBcontext;
        }

        public List<ActivityEntity> GetList(int? page = null, int? take = null, string searchText = null)
        {
            IQueryable<ActivityEntity> query = DBcontext.Activity.OrderByDescending(o => o.Id);

            if (searchText != null)
                query = query.Where(i => i.Name.Contains(searchText));

            if (page != null && take != null)
                query = query.Skip((page.Value - 1) * take.Value).Take(take.Value);

            return query.ToList();
        }

        public int Create(ActivityEntity entity)
        {
            DBcontext.Activity.Add(entity);
            DBcontext.SaveChanges();
            return entity.Id;
        }
    }
}
