using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ICourseService _courseService;

        [BindProperty]
        public UpdateCourseDto Course { get; set; } = new();

        [BindProperty]
        public int CourseId { get; set; }
        public EditModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            CourseId = course.CourseId;

            Course.Title = course.Title;
            Course.Description = course.Description;
            Course.Price = course.Price;
            Course.IsPublished = course.IsPublished;
            Course.InstructorId = course.InstructorId;
            Course.CategoryId = course.CategoryId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _courseService.UpdateCourseAsync(
                CourseId,
                Course
            );

            if (!success)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}