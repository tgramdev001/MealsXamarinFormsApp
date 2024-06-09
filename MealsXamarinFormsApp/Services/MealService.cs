using MealsXamarinFormsApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MealsXamarinFormsApp.Services
{
    public class MealService : IMealService
    {
        private readonly HttpClient _httpClient;

        public MealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MealResponse> GetMealAsync(string mealId)
        {
            var response = await _httpClient.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={mealId}");
            return JsonConvert.DeserializeObject<MealResponse>(response);
        }

        public async Task<CategoryResponse> GetCategoriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.themealdb.com/api/json/v1/1/categories.php");
            return JsonConvert.DeserializeObject<CategoryResponse>(response);
        }

        public async Task<MealSummaryResponse> GetMealSummaryAsync(string mealId)
        {
            var response = await _httpClient.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/filter.php?c={mealId}");
            return JsonConvert.DeserializeObject<MealSummaryResponse>(response);
        }
    }
}
