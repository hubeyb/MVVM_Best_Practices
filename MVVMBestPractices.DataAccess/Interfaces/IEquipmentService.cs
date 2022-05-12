using MVVMBestPractices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.DataAccess
{
    public interface IEquipmentService
    {
        List<EquipmentEntity> GetList();

        int Create(EquipmentEntity entity);
    }
}
