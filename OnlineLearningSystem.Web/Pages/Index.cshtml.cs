using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public List<CategoryDto> Categories { get; set; } = new();

        public List<CourseDto> FeaturedCourses { get; set; } = new();

        public int CourseCount { get; set; }

        public IndexModel(
            ICategoryService categoryService,
            ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();

            var courses = await _courseService.GetCoursesAsync();

            CourseCount = courses.Count;

            FeaturedCourses = courses
                .Where(c => c.IsPublished)
                .Take(6)
                .ToList();
        }
    }
}