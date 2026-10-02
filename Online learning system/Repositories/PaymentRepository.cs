using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OnlineLearningDbContext _context;

        public PaymentRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Student)
                .Include(p => p.Course)
                .ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Student)
                .Include(p => p.Course)
                .FirstOrDefaultAsync(
                    p => p.PaymentId == id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task DeleteAsync(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}