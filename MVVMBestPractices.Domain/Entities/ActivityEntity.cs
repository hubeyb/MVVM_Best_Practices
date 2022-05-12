using System;

namespace MVVMBestPractices.Domain.Entities
{
    public class ActivityEntity : OperationHistoryEntityBase
    {
        public string Name { get; set; }
    }
}
