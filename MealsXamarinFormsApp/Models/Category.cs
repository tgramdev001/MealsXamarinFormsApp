using System;
using System.Collections.Generic;
using System.Text;

namespace MealsXamarinFormsApp.Models
{
    public class Category
    {
        public string IdCategory { get; set; }
        public string StrCategory { get; set; }
        public string StrCategoryThumb { get; set; }
        public string StrCategoryDescription { get; set; }
    }

    public class CategoryResponse
    {
        public List<Category> Categories { get; set; }
    }
}
