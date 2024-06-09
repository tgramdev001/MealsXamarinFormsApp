using MealsXamarinFormsApp.Models;
using MealsXamarinFormsApp.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MealsXamarinFormsApp.Tests
{
    public class MealServiceTests
    {
        private readonly Mock<HttpClient> _httpClientMock;
        private readonly IMealService _mealService;

        public MealServiceTests()
        {
            _httpClientMock = new Mock<HttpClient>();
            _mealService = new MealService(_httpClientMock.Object);
        }

        [Fact]
        public async Task GetMealAsync_ReturnsMealResponse()
        {
            var mealId = "52772";
            var mealResponse = new MealResponse { Meals = new List<Meal> { new Meal { IdMeal = mealId, StrMeal = "Teriyaki Chicken Casserole" } } };
            var jsonResponse = JsonConvert.SerializeObject(mealResponse);

            _httpClientMock.Setup(client => client.GetStringAsync(It.IsAny<string>())).ReturnsAsync(jsonResponse);

            var result = await _mealService.GetMealAsync(mealId);

            Assert.NotNull(result);
            Assert.Single(result.Meals);
            Assert.Equal(mealId, result.Meals[0].IdMeal);
        }

        [Fact]
        public async Task GetSeafoodMealsAsync_ReturnsMealSummaryResponse()
        {
            var mealSummaryResponse = new MealSummaryResponse { Meals = new List<MealSummary> { new MealSummary { IdMeal = "52959", StrMeal = "Baked salmon with fennel & tomatoes" } } };
            var jsonResponse = JsonConvert.SerializeObject(mealSummaryResponse);

            _httpClientMock.Setup(client => client.GetStringAsync(It.IsAny<string>())).ReturnsAsync(jsonResponse);

            var result = await _mealService.GetMealSummaryAsync("Seafood");

            Assert.NotNull(result);
            Assert.Single(result.Meals);
            Assert.Equal("52959", result.Meals[0].IdMeal);
        }

        [Fact]
        public async Task GetCategoriesAsync_ReturnsCategoryResponse()
        {
            var categoryResponse = new CategoryResponse { Categories = new List<Category> { new Category { IdCategory = "1", StrCategory = "Beef" } } };
            var jsonResponse = JsonConvert.SerializeObject(categoryResponse);

            _httpClientMock.Setup(client => client.GetStringAsync(It.IsAny<string>())).ReturnsAsync(jsonResponse);

            var result = await _mealService.GetCategoriesAsync();

            Assert.NotNull(result);
            Assert.Single(result.Categories);
            Assert.Equal("1", result.Categories[0].IdCategory);
        }
    }
}
