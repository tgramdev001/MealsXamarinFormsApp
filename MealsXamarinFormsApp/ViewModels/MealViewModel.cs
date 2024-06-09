using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealsXamarinFormsApp.ViewModels
{
    public class MealViewModel : INotifyPropertyChanged
    {
        private readonly IMealService _mealService;
        private Meal _meal;

        public Meal Meal
        {
            get => _meal;
            set
            {
                _meal = value;
                OnPropertyChanged();
            }
        }

        public MealViewModel(IMealService mealService, string idMeal)
        {
            _mealService = mealService ?? throw new ArgumentNullException(nameof(mealService));
            Task.Run(async () =>
            {
                await LoadMeal(idMeal);
            }).Wait();
        }

        private async Task LoadMeal(string idMeal)
        {
            try
            {
                Meal = await _mealService.GetMealDetailsAsync(idMeal);
            }
            catch (Exception ex)
            {
                // Handle error
                Console.WriteLine($"Error loading meal: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
