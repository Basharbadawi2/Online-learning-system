using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);

        Task AddAsync(Payment payment);
        Task DeleteAsync(Payment payment);

        Task SaveChangesAsync();
    }
}