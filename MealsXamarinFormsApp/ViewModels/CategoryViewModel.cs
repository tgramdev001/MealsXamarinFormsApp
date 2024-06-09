using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealsXamarinFormsApp.ViewModels
{
    public class CategoryViewModel : BindableObject
    {

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private readonly IMealService _mealService;

        public CategoryViewModel(IMealService mealService)
        {
            _mealService = mealService;
            Categories = new ObservableCollection<Category>();
        }

        public async Task LoadCategoriesAsync()
        {
            var categoryResponse = await _mealService.GetCategoriesAsync();
            if (categoryResponse?.Categories != null)
            {
                foreach (var category in categoryResponse.Categories)
                {
                    Categories.Add(category);
                }
            }
        }
    }
}
