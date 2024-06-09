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
    public partial class MealSummaryPage : ContentPage
    {
        public MealSummaryPage(string category)
        {
            InitializeComponent();
            Title = "Meal Summary - " + category;
            BindingContext = new MealSummaryViewModel(App.ServiceProvider.GetService<IMealService>(), category);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var mealSummary = e.SelectedItem as MealSummary;
            if (mealSummary != null)
            {
                await Navigation.PushAsync(new MealPage(mealSummary.IdMeal));
                (sender as ListView).SelectedItem = null;
            }
        }

        private async void OnBackToCategoriesClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Navigate back to CategoriesPage
        }
    }
}