using GalaSoft.MvvmLight.Command;
using MVVMBestPractices.Domain.Entities;
using MVVMBestPractices.Logic.ViewModels;
using System;
using System.Windows;

namespace MVVMBestPractices.WpfUI
{
    /// <summary>
    /// Interaction logic for ActivityWindow.xaml
    /// </summary>
    public partial class ActivityWindow : Window
    {
        ActivityViewModel ActivityViewModel;

        public ActivityWindow(ActivityViewModel activityViewModel)
        {
            InitializeComponent();

            Closing += ActivityWindow_Closing;
            
            //Can be use for update operation
            //Activated += ActivityWindow_Activated;

            ActivityViewModel = activityViewModel;

            ActivityViewModel.SaveCommand = new RelayCommand(() => {
                var entity = new ActivityEntity()
                {
                    Name = ActivityViewModel.Name,
                    CreatedBy = "App User",
                    CreatedOn = DateTime.Now,
                    LastModifiedOn = DateTime.Now,
                };

                ActivityViewModel.ActivityService.Create(entity);

                Hide();

                ActivityViewModel.ActivityList.Add(entity);
                ActivityViewModel.ClearSearchAndRefreshGrid();
            });

            DataContext = ActivityViewModel;
        }

        //Can be use for update operation
        //private void ActivityWindow_Activated(object? sender, EventArgs e)
        //{
        //    DataContext = ActivityViewModel.SelectedActivity;
        //}

        private void ActivityWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
