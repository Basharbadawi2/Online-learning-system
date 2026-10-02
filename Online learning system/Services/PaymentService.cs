using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository
            _paymentRepository;

        public PaymentService(
            IPaymentRepository paymentRepository)
        {
            _paymentRepository =
                paymentRepository;
        }

        public async Task<List<Payment>>
            GetAllPaymentsAsync()
        {
            return await _paymentRepository
                .GetAllAsync();
        }

        public async Task<Payment?>
            GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository
                .GetByIdAsync(id);
        }

        public async Task<string>
            CreatePaymentAsync(
            CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                Amount = dto.Amount,
                PaymentStatus = dto.PaymentStatus,
                TransactionReference =
                    dto.TransactionReference
            };

            if (dto.PaymentStatus == "Completed")
            {
                payment.PaidAt = DateTime.Now;
            }

            await _paymentRepository
                .AddAsync(payment);

            await _paymentRepository
                .SaveChangesAsync();

            return "Payment created successfully.";
        }

        public async Task<bool>
            DeletePaymentAsync(int id)
        {
            var payment =
                await _paymentRepository
                .GetByIdAsync(id);

            if (payment == null)
            {
                return false;
            }

            await _paymentRepository
                .DeleteAsync(payment);

            await _paymentRepository
                .SaveChangesAsync();

            return true;
        }
    }
}