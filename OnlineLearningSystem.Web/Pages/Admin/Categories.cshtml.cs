using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Admin
{
    public class CategoriesModel : PageModel
    {
        private readonly ICategoryService _categoryService;


    public List<CategoryDto> Categories { get; set; } = new();

        public CategoriesModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();
        }
    }


}
