using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModulesController(
            IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var modules =
                await _moduleService.GetAllModulesAsync();

            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var module =
                await _moduleService.GetModuleByIdAsync(id);

            if (module == null)
            {
                return NotFound("Module not found.");
            }

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule(
            CreateModuleDto dto)
        {
            await _moduleService.CreateModuleAsync(dto);

            return Ok("Module created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(
            int id,
            UpdateModuleDto dto)
        {
            var result =
                await _moduleService.UpdateModuleAsync(
                    id,
                    dto);

            if (!result)
            {
                return NotFound("Module not found.");
            }

            return Ok("Module updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var result =
                await _moduleService.DeleteModuleAsync(id);

            if (!result)
            {
                return NotFound("Module not found.");
            }

            return Ok("Module deleted successfully.");
        }
    }
}