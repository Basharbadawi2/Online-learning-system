using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class CertificateService
        : ICertificateService
    {
        private readonly ICertificateRepository
            _certificateRepository;

        public CertificateService(
            ICertificateRepository certificateRepository)
        {
            _certificateRepository =
                certificateRepository;
        }

        public async Task<List<Certificate>>
            GetAllCertificatesAsync()
        {
            return await _certificateRepository
                .GetAllAsync();
        }

        public async Task<Certificate?>
            GetCertificateByIdAsync(int id)
        {
            return await _certificateRepository
                .GetByIdAsync(id);
        }

        public async Task<string>
            CreateCertificateAsync(
            CreateCertificateDto dto)
        {
            var existingCertificate =
                await _certificateRepository
                .GetByEnrollmentIdAsync(
                    dto.EnrollmentId);

            if (existingCertificate != null)
            {
                return "Certificate already exists for this enrollment.";
            }

            string certificateNumber;

            do
            {
                certificateNumber =
                    "CERT-" +
                    Guid.NewGuid()
                        .ToString("N")
                        .Substring(0, 8)
                        .ToUpper();

            } while (
                await _certificateRepository
                    .GetByNumberAsync(
                        certificateNumber)
                    != null);

            var certificate = new Certificate
            {
                EnrollmentId = dto.EnrollmentId,
                CertificateNumber =
                    certificateNumber,
                IssuedAt = DateTime.Now
            };

            await _certificateRepository
                .AddAsync(certificate);

            await _certificateRepository
                .SaveChangesAsync();

            return certificateNumber;
        }

        public async Task<bool>
            DeleteCertificateAsync(int id)
        {
            var certificate =
                await _certificateRepository
                .GetByIdAsync(id);

            if (certificate == null)
            {
                return false;
            }

            await _certificateRepository
                .DeleteAsync(certificate);

            await _certificateRepository
                .SaveChangesAsync();

            return true;
        }
    }
}