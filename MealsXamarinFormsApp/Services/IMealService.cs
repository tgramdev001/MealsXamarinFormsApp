using MealsXamarinFormsApp.Models;
using System.Threading.Tasks;

namespace MealsXamarinFormsApp.Services
{
    public interface IMealService
    {
        Task<MealResponse> GetMealAsync(string mealId);
        Task<MealSummaryResponse> GetMealSummaryAsync(string mealId);
        Task<CategoryResponse> GetCategoriesAsync();
    }
}
