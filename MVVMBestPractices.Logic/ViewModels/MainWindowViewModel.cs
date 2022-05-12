using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Logic.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ActivityViewModel ActivityVM { get; set; }
        public EquipmentViewModel EquipmentVM { get; set; }

        public MainWindowViewModel(ActivityViewModel activityViewModel, EquipmentViewModel equipmentViewModel)
        {
            ActivityVM = activityViewModel;
            ActivityVM.IsVisible = true;

            EquipmentVM = equipmentViewModel;
            EquipmentVM.IsVisible = false;
        }
    }
}