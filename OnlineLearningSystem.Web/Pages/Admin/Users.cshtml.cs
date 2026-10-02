using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly IUserService _userService;

        public List<UserDto> Users { get; set; } = new();

        public UsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Users = await _userService.GetUsersAsync();
        }
    }
}