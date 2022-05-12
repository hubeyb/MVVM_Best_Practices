﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Domain.Entities
{
    public class EquipmentEntity : OperationHistoryEntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }
    }
}
