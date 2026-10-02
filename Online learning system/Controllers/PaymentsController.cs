using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService
            _paymentService;

        public PaymentsController(
            IPaymentService paymentService)
        {
            _paymentService =
                paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments =
                await _paymentService
                .GetAllPaymentsAsync();

            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment =
                await _paymentService
                .GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound(
                    "Payment not found.");
            }

            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreatePaymentDto dto)
        {
            var result =
                await _paymentService
                .CreatePaymentAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _paymentService
                .DeletePaymentAsync(id);

            if (!result)
            {
                return NotFound(
                    "Payment not found.");
            }

            return Ok(
                "Payment deleted successfully.");
        }
    }
}