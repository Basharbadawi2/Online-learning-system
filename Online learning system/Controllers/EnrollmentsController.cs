using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService
            _enrollmentService;

        public EnrollmentsController(
            IEnrollmentService enrollmentService)
        {
            _enrollmentService =
                enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult>
            GetAllEnrollments()
        {
            return Ok(
                await _enrollmentService
                .GetAllEnrollmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetEnrollmentById(int id)
        {
            var enrollment =
                await _enrollmentService
                .GetEnrollmentByIdAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult>
            CreateEnrollment(
            CreateEnrollmentDto dto)
        {
            var result =
                await _enrollmentService
                .CreateEnrollmentAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            DeleteEnrollment(int id)
        {
            var result =
                await _enrollmentService
                .DeleteEnrollmentAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(
                "Enrollment deleted successfully.");
        }
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetStudentEnrollments(int studentId)
        {
            var enrollments =
                await _enrollmentService
                .GetEnrollmentsByStudentAsync(studentId);

            return Ok(enrollments);
        }
    }
}