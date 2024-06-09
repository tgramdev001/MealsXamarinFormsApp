using MealsXamarinFormsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealsXamarinFormsApp.Services
{
    public interface IMealService
    {
        Task<Meal> GetMealDetailsAsync(string idMeal);
        Task<List<MealSummary>> GetMealSummaryAsync(string category);
        Task<CategoryResponse> GetCategoriesAsync();
    }
}
