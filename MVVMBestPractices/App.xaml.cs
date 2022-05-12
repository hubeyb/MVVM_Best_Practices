using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVVMBestPractices.DataAccess;
using MVVMBestPractices.DataAccess.DataContext;
using MVVMBestPractices.DataAccess.Services;
using MVVMBestPractices.Logic.ViewModels;
using MVVMBestPractices.WpfUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMBestPractices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<IMVVMBestPracticesDBcontext, MVVMBestPracticesDBcontext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<ActivityWindow>();
            services.AddSingleton<EquipmentWindow>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ActivityViewModel>();
            services.AddSingleton<EquipmentViewModel>();

            services.AddSingleton<IEquipmentService, EquipmentService>();
            services.AddSingleton<IActivityService, ActivityService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
