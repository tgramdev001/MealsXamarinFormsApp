using MealsXamarinFormsApp.Services;
using MealsXamarinFormsApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Xamarin.Forms;

namespace MealsXamarinFormsApp
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            InitializeComponent();
            ConfigureServices();
            MainPage = new NavigationPage(new MainPage());
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(new HttpClient());
            services.AddSingleton<IMealService, MealService>();
            services.AddTransient<MealViewModel>();
            services.AddTransient<MealSummaryViewModel>();
            services.AddTransient<CategoryViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
