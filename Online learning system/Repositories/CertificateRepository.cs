using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class CertificateRepository
        : ICertificateRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CertificateRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Certificate>> GetAllAsync()
        {
            return await _context.Certificates
                .Include(c => c.Enrollment)
                .ThenInclude(e => e.Student)
                .Include(c => c.Enrollment)
                .ThenInclude(e => e.Course)
                .ToListAsync();
        }

        public async Task<Certificate?> GetByIdAsync(
            int id)
        {
            return await _context.Certificates
                .Include(c => c.Enrollment)
                .ThenInclude(e => e.Student)
                .Include(c => c.Enrollment)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(
                    c => c.CertificateId == id);
        }

        public async Task<Certificate?>
            GetByEnrollmentIdAsync(
            int enrollmentId)
        {
            return await _context.Certificates
                .FirstOrDefaultAsync(
                    c => c.EnrollmentId == enrollmentId);
        }

        public async Task<Certificate?>
            GetByNumberAsync(
            string certificateNumber)
        {
            return await _context.Certificates
                .FirstOrDefaultAsync(
                    c => c.CertificateNumber
                        == certificateNumber);
        }

        public async Task AddAsync(
            Certificate certificate)
        {
            await _context.Certificates
                .AddAsync(certificate);
        }

        public async Task DeleteAsync(
            Certificate certificate)
        {
            _context.Certificates.Remove(certificate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}