using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface ICertificateRepository
    {
        Task<List<Certificate>> GetAllAsync();

        Task<Certificate?> GetByIdAsync(int id);

        Task<Certificate?> GetByEnrollmentIdAsync(
            int enrollmentId);

        Task<Certificate?> GetByNumberAsync(
            string certificateNumber);

        Task AddAsync(Certificate certificate);

        Task DeleteAsync(Certificate certificate);

        Task SaveChangesAsync();
    }
}