using GarbarenkoSpaVisitJournal.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GarbarenkoSpaVisitJournal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainViewModel viewModel;
        public IConfiguration Configuration { get; private set; }
        protected override async void OnStartup(StartupEventArgs e)
        {
            this.Configure();
            this.viewModel = new MainViewModel(Configuration.GetConnectionString("DockerMsSqlDB"));
            //viewModel.AppContext.Database.EnsureCreated();
        }
        private void Configure()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + @"/cfg/")
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        protected override async void OnExit(ExitEventArgs e)
        {

            //viewModel.AppContext.SaveChanges();
            viewModel.contextJson.SaveChanges();
            //viewModel.AppContext.Dispose();
            base.OnExit(e);

        }
    }
 }
