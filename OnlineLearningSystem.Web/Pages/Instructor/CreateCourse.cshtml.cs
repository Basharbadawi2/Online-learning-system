using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Instructor
{
    public class CreateCourseModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly IInstructorService _instructorService;
        private readonly IAuthSession _authSession;

        [BindProperty]
        public CreateCourseDto Course { get; set; } = new();

        public List<CategoryDto> Categories { get; set; } = new();

        public CreateCourseModel(
            ICourseService courseService,
            ICategoryService categoryService,
            IInstructorService instructorService,
            IAuthSession authSession)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _instructorService = instructorService;
            _authSession = authSession;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();

            var instructor = await _instructorService
                .GetInstructorByUserAsync(_authSession.UserId);

            Course.InstructorId = instructor?.InstructorId ?? 0;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructor = await _instructorService
                .GetInstructorByUserAsync(_authSession.UserId);

            if (instructor == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No instructor profile found for this account.");

                return Page();
            }

            Course.InstructorId = instructor.InstructorId;

            var success = await _courseService.CreateCourseAsync(Course);

            if (!success)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Unable to create the course. Please try again."
                );

                return Page();
            }

            return RedirectToPage("./Courses");
        }
    }
}