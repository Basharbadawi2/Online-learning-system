using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPaymentsAsync();

        Task<Payment?> GetPaymentByIdAsync(int id);

        Task<string> CreatePaymentAsync(
            CreatePaymentDto dto);

        Task<bool> DeletePaymentAsync(int id);
    }
}