using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;

namespace MVVMBestPractices.Logic.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public RelayCommand SaveCommand { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseModel()
        {
            InitCommands();
        }

        /// <summary>
        /// Override this method in derived types to initialize command logic
        /// </summary>
        protected virtual void InitCommands()
        {
        }
    }
}
