using System;
using System.Collections.Generic;
using System.Text;

namespace MealsXamarinFormsApp.Models
{
    public class MealSummary
    {
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
        public string IdMeal { get; set; }
    }

    public class MealSummaryResponse
    {
        public List<MealSummary> Meals { get; set; }
    }
}
