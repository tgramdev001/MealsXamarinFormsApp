using MealsXamarinFormsApp.Models;
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
    public partial class CategoriesPage : ContentPage
    {
        private readonly CategoryViewModel _viewModel;
        public CategoriesPage()
        {
            InitializeComponent();
            Title = "Meal categories";
            _viewModel = App.ServiceProvider.GetService<CategoryViewModel>();
            BindingContext = _viewModel;

        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as Category;
            if (selectedCategory != null)
            {
                await Navigation.PushAsync(new MealSummaryPage(selectedCategory.StrCategory));
                (sender as ListView).SelectedItem = null;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadCategoriesAsync();
        }
    }
}