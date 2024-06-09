using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using MealsXamarinFormsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsXamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealPage : ContentPage
    {
        private readonly MealSummaryViewModel _viewModel;
        public MealPage(string idMeal)
        {
            InitializeComponent();
            BindingContext = new MealViewModel(App.ServiceProvider.GetService<IMealService>(), idMeal);
        }
    }
}