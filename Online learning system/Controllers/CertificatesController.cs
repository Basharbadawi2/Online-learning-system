using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateService
            _certificateService;

        public CertificatesController(
            ICertificateService certificateService)
        {
            _certificateService =
                certificateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var certificates =
                await _certificateService
                .GetAllCertificatesAsync();

            return Ok(certificates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var certificate =
                await _certificateService
                .GetCertificateByIdAsync(id);

            if (certificate == null)
            {
                return NotFound(
                    "Certificate not found.");
            }

            return Ok(certificate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateCertificateDto dto)
        {
            var result =
                await _certificateService
                .CreateCertificateAsync(dto);

            if (result ==
                "Certificate already exists for this enrollment.")
            {
                return BadRequest(result);
            }

            return Ok(new
            {
                message =
                    "Certificate created successfully.",
                certificateNumber = result
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _certificateService
                .DeleteCertificateAsync(id);

            if (!result)
            {
                return NotFound(
                    "Certificate not found.");
            }

            return Ok(
                "Certificate deleted successfully.");
        }
    }
}