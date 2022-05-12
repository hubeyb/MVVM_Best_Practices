using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Logic.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
