using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealsXamarinFormsApp.ViewModels
{
    public class MealViewModel : BindableObject
    {
        private ObservableCollection<Meal> _meals;
        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                OnPropertyChanged();
            }
        }

        private readonly IMealService _mealService;

        public MealViewModel(IMealService mealService)
        {
            _mealService = mealService;
            Meals = new ObservableCollection<Meal>();
        }

        public async Task LoadMealAsync(string mealId)
        {
            var mealResponse = await _mealService.GetMealAsync(mealId);
            if (mealResponse?.Meals != null)
            {
                foreach (var meal in mealResponse.Meals)
                {
                    Meals.Add(meal);
                }
            }
        }
    }

}
