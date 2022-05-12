using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Logic.ViewModels
{
    public abstract class OperationHistoryViewModelBase : BaseViewModel
    {
        [Required]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public RelayCommand SearchCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand RefreshGridCommand { get; set; }
    }
}
