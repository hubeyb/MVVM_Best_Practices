using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMBestPractices.DataAccess;
using MVVMBestPractices.DataAccess.DataContext;
using MVVMBestPractices.DataAccess.Services;
using MVVMBestPractices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMBestPractices.Tests.UnitTests
{
    [TestClass]
    public class ActivityUnitTests : UnitTestsBase
    {
        public IActivityService ActivityService;

        [TestMethod]
        public void Activity_GetList_Should_Return_5_Activity()
        {
            //Arrange (In MockDependencies method)

            //Act
            var activities = ActivityService.GetList();

            //Assert  
            Assert.IsNotNull(activities);
            Assert.AreEqual(5, activities.Count);
        }

        [TestMethod]
        public void Activity_Create_Should_Return_Same_Name()
        {
            //Arrange
            var activity = new ActivityEntity()
            {
                Id = 10,
                Name = $"Activity Name test",
                CreatedBy = "Sytem Default User",
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
            };

            //Act
            ActivityService.Create(activity);
            var newActivity = ActivityService.GetList().Where(i=> i.Id == activity.Id).FirstOrDefault();

            //Assert
            Assert.IsNotNull(newActivity);
            Assert.AreEqual(activity.Name, newActivity.Name);
        }

        protected override void MockDependencies()
        {
            //Arrange
            dBContext = MockDBContext.GetMockDBContext();

            ActivityService = new ActivityService(dBContext);

            var activityList = new List<ActivityEntity>();


            for (int i = 1; i <= 5; i++)
            {
                activityList.Add(new ActivityEntity()
                {
                    Id = i,
                    Name = $"Activity Name test {i}",
                    CreatedBy = "Sytem Default User",
                    CreatedOn = DateTime.Now.AddDays(-i),
                    LastModifiedOn = DateTime.Now.AddDays(-i),
                });
            }

            dBContext.Activity.AddRange(activityList);
            dBContext.SaveChanges();
        }
    }
}
