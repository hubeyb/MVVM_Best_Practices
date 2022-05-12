using MVVMBestPractices.DataAccess.DataContext;
using MVVMBestPractices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.DataAccess.Services
{
    public class EquipmentService : IEquipmentService
    {
        private IMVVMBestPracticesDBcontext DBcontext;

        public EquipmentService(IMVVMBestPracticesDBcontext dBcontext)
        {
            DBcontext = dBcontext;
        }

        public List<EquipmentEntity> GetList()
        {
            var list = DBcontext.Equipment.ToList();
            return list;
        }

        public int Create(EquipmentEntity entity)
        {
            DBcontext.Equipment.Add(entity);
            var id = DBcontext.SaveChanges();
            return id;
        }
    }
}
