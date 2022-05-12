using GalaSoft.MvvmLight.Command;
using MVVMBestPractices.DataAccess;
using MVVMBestPractices.Domain.Entities;
using MVVMBestPractices.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Logic.ViewModels
{
    public class ActivityViewModel : OperationHistoryViewModelBase
    {
        public int Page = 1;
        public const int Take = 25;
        public IActivityService ActivityService;

        #region Fields
        private bool previousCommandIsEnabled;
        private bool nextCommandIsEnabled;
        private string paginationText;
        #endregion


        #region Properties

        /// <summary>
        /// Name of Activity
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>
        /// Selected Activity on grid
        /// </summary>
        public ActivityEntity SelectedActivity { get; set; }

        /// <summary>
        /// Activity list of grid
        /// </summary>
        public List<ActivityEntity> ActivityList { get; set; }

        /// <summary>
        /// Activity grid Observable Collection data
        /// </summary>
        public ObservableCollection<ActivityEntity> Activities { get; set; }

        /// <summary>
        /// Activity Viewmodel screen is visible
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// search text to filter data on data grid
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Pagination previous button command
        /// </summary>
        public RelayCommand PreviousCommand { get; set; }

        /// <summary>
        /// Pagination Next button command
        /// </summary>
        public RelayCommand NextCommand { get; set; }

        /// <summary>
        /// Previous button is enabled
        /// </summary>
        public bool PreviousCommandIsEnabled
        {
            get { return previousCommandIsEnabled; }
            set
            {
                previousCommandIsEnabled = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Next button is enabled
        /// </summary>
        public bool NextCommandIsEnabled
        {
            get { return nextCommandIsEnabled; }
            set
            {
                nextCommandIsEnabled = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Page info text
        /// </summary>
        public string PaginationText
        {
            get { return paginationText; }
            set
            {
                paginationText = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public ActivityViewModel(IActivityService activityService)
        {
            ActivityService = activityService;

            CreateDummyData();

            Activities = new ObservableCollection<ActivityEntity>();

            RefreshGrid();


            #region Commands

            SearchCommand = new RelayCommand(() =>
            {
                Page = 1;
                RefreshGrid();
            });

            PreviousCommand = new RelayCommand(() =>
            {
                Page = Page > 1 ? Page - 1 : Page;
                RefreshGrid();
            });

            NextCommand = new RelayCommand(() =>
            {
                Page = ActivityList.Count > 0 ? Page + 1 : Page;
                RefreshGrid();
            });

            RefreshGridCommand = new RelayCommand(() => {
                ClearSearchAndRefreshGrid();
            });

            #endregion
        }

        public void RefreshGrid()
        {
            ActivityList = ActivityService.GetList(Page, Take, SearchText);

            Activities.Clear();

            ActivityList.ForEach(activity => { Activities.Add(activity); });

            PaginationText = $"Page: {Page}";

            if (Activities.Any())
            {
                PreviousCommandIsEnabled = Page > 1 ? true : false;
                NextCommandIsEnabled = true;
            }
            else
            {
                PreviousCommandIsEnabled = true;
                NextCommandIsEnabled = false;
            }
        }

        public void ClearSearchAndRefreshGrid()
        {
            SearchText = "";
            Page = 1;
            RefreshGrid();
        }

        private void CreateDummyData()
        {
            for (int i = 1; i <= 75; i++)
            {
                ActivityService.Create(new ActivityEntity()
                {
                    Id = i,
                    Name = $"Activity Name test {i}",
                    CreatedBy = "Sytem Default User",
                    CreatedOn = DateTime.Now.AddDays(-i),
                    LastModifiedOn = DateTime.Now.AddDays(-i),
                });
            }
        }
    }
}
