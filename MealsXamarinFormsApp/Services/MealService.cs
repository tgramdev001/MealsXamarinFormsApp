using MealsXamarinFormsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MealsXamarinFormsApp.Services
{
    public class MealService : IMealService
    {
        private readonly HttpClient _httpClient;

        public MealService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CategoryResponse> GetCategoriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.themealdb.com/api/json/v1/1/categories.php");
            return JsonConvert.DeserializeObject<CategoryResponse>(response);
        }

        public async Task<Meal> GetMealDetailsAsync(string idMeal)
        {
            var url = $"https://www.themealdb.com/api/json/v1/1/lookup.php?i={idMeal}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve data: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MealResponse>(content);
            return result.Meals[0];
        }

        public async Task<List<MealSummary>> GetMealSummaryAsync(string category)
        {
            var url = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={category}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve data: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MealSummaryResponse>(content);
            return result.Meals;
        }
    }
}
