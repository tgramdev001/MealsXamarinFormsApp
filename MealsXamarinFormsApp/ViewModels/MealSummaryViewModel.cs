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
    public class MealSummaryViewModel : BindableObject
    {

        private ObservableCollection<MealSummary> _meals;
        public ObservableCollection<MealSummary> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                OnPropertyChanged();
            }
        }

        private readonly IMealService _mealService;

        public MealSummaryViewModel(IMealService mealService)
        {
            _mealService = mealService;
            Meals = new ObservableCollection<MealSummary>();
        }

        public async Task LoadMealSummaryAsync(string mealId)
        {
            var mealSummaryResponse = await _mealService.GetMealSummaryAsync(mealId);
            if (mealSummaryResponse?.Meals != null)
            {
                foreach (var meal in mealSummaryResponse.Meals)
                {
                    Meals.Add(meal);
                }
            }
        }
    }
}
