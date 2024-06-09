using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MealsXamarinFormsApp.ViewModels
{
    public class MealSummaryViewModel : BindableObject
    {
        private readonly IMealService _mealService;

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
                LoadSummary(Category); // Reload the summary when category changes
            }
        }

        private List<MealSummary> _mealSummaries;
        public List<MealSummary> MealSummaries
        {
            get => _mealSummaries;
            set
            {
                _mealSummaries = value;
                OnPropertyChanged();
            }
        }

        public MealSummaryViewModel(IMealService mealService, string category)
        {
            _mealService = mealService ?? throw new ArgumentNullException(nameof(mealService));
            Category = category;
        }

        private async void LoadSummary(string category)
        {
            try
            {
                MealSummaries = await _mealService.GetMealSummaryAsync(category);
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }
    }

}
