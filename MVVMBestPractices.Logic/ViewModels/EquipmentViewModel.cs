using GalaSoft.MvvmLight.Command;
using MVVMBestPractices.DataAccess;
using MVVMBestPractices.Domain.Entities;
using MVVMBestPractices.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Logic.ViewModels
{
    public class EquipmentViewModel : OperationHistoryViewModelBase
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public bool IsVisible { get; set; }


        public EquipmentEntity SelectedActivity { get; set; }

        public ObservableCollection<EquipmentEntity> Equipments { get; set; }

        public IEquipmentService EquipmentService;


        public EquipmentViewModel(IEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;

            for (int i = 1; i <= 50; i++)
            {
                EquipmentService.Create(new EquipmentEntity()
                {
                    Id = i,
                    Name = $"Equipment Name test {i}",
                    Type = $"Equipment Type test {i}",
                    Quantity = i + 10,
                    CreatedBy = "Sytem Default User",
                    CreatedOn = DateTime.Now.AddDays(-i),
                    LastModifiedOn = DateTime.Now.AddDays(-i),
                });
            }

            var equipmentsList = EquipmentService.GetList();

            Equipments = new ObservableCollection<EquipmentEntity>(equipmentsList);
        }
    }
}
