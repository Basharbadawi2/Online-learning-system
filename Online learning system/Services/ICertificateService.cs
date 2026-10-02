using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface ICertificateService
    {
        Task<List<Certificate>>
            GetAllCertificatesAsync();

        Task<Certificate?>
            GetCertificateByIdAsync(int id);

        Task<string>
            CreateCertificateAsync(
                CreateCertificateDto dto);

        Task<bool>
            DeleteCertificateAsync(int id);
    }
}