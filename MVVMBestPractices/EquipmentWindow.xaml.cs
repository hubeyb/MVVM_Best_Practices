using GalaSoft.MvvmLight.Command;
using MVVMBestPractices.Domain.Entities;
using MVVMBestPractices.Logic.ViewModels;
using System;
using System.Windows;

namespace MVVMBestPractices.WpfUI
{
    /// <summary>
    /// Interaction logic for EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        EquipmentViewModel EquipmentViewModel;

        public EquipmentWindow(EquipmentViewModel equipmentViewModel)
        {
            InitializeComponent();

            Closing += EquipmentWindow_Closing;

            //Can be use for update operation
            //Activated += EquipmentWindow_Activated;

            EquipmentViewModel = equipmentViewModel;

            EquipmentViewModel.SaveCommand = new RelayCommand(() =>
            {
                var entity = new EquipmentEntity()
                {
                    Name = EquipmentViewModel.Name,
                    Type = EquipmentViewModel.Type,
                    Quantity = EquipmentViewModel.Quantity,
                    CreatedBy = "App User",
                    CreatedOn = DateTime.Now,
                    LastModifiedOn = DateTime.Now,
                };

                EquipmentViewModel.EquipmentService.Create(entity);
                Hide();

                EquipmentViewModel.Equipments.Add(entity);

                EquipmentViewModel.Name = "";
                EquipmentViewModel.Type = "";
                EquipmentViewModel.Quantity = 0;
            });

            DataContext = EquipmentViewModel;
        }

        //Can be use for update operation
        //private void EquipmentWindow_Activated(object? sender, EventArgs e)
        //{
        //    DataContext = EquipmentViewModel.SelectedActivity;
        //}

        private void EquipmentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
