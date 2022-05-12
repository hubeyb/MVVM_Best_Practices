using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.DependencyInjection;
using MVVMBestPractices.Logic;
using MVVMBestPractices.Logic.Models;
using MVVMBestPractices.Logic.ViewModels;
using MVVMBestPractices.WpfUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMBestPractices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ActivityWindow ActivityWindow;
        EquipmentWindow EquipmentWindow;
        MainWindowViewModel MainWindowViewModel;

        public MainWindow(MainWindowViewModel mainWindowViewModel, ActivityWindow activityWindow, EquipmentWindow equipmentWindow)
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
            MainWindowViewModel = mainWindowViewModel;

            ActivityWindow = activityWindow;
            EquipmentWindow = equipmentWindow;

            mainWindowViewModel.ActivityVM.CreateCommand = new RelayCommand(() =>
            {
                ActivityWindow.Show();
            });

            mainWindowViewModel.EquipmentVM.CreateCommand = new RelayCommand(() =>
            {
                EquipmentWindow.Show();
            });

            mainWindowViewModel.ActivityVM.PropertyChanged += ActivityVM_PropertyChanged;
        }

        private void ActivityVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            DataContext = null;
            DataContext = MainWindowViewModel;
        }

        private void Activities_Click(object sender, RoutedEventArgs e)
        {
            var activityVM = MainWindowViewModel.ActivityVM;
            var equipmentVM = MainWindowViewModel.EquipmentVM;

            activityVM.IsVisible = true;
            equipmentVM.IsVisible = false;

            activityVM.ClearSearchAndRefreshGrid();

            DataContext = null;
            DataContext = MainWindowViewModel;
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            var activityVM = MainWindowViewModel.ActivityVM;
            var equipmentVM = MainWindowViewModel.EquipmentVM;

            activityVM.IsVisible = false;
            equipmentVM.IsVisible = true;

            DataContext = null;
            DataContext = MainWindowViewModel;
        }
    }
}
