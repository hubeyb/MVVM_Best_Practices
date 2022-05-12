using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Domain.Entities
{
    public abstract class OperationHistoryEntityBase : EntityBase
    {
        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
