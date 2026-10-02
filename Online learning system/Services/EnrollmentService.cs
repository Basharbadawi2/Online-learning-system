using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace Online_learning_system.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository
            _enrollmentRepository;

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository =
                enrollmentRepository;
        }

        public async Task<List<Enrollment>>
            GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository
                .GetAllAsync();
        }

        public async Task<Enrollment?>
            GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository
                .GetByIdAsync(id);
        }

        public async Task<List<Enrollment>>
            GetEnrollmentsByStudentAsync(int studentId)
        {
            return await _enrollmentRepository
                .GetByStudentAsync(studentId);
        }

        public async Task<string>
            CreateEnrollmentAsync(
            CreateEnrollmentDto dto)
        {
            var existing =
                await _enrollmentRepository
                .GetByStudentAndCourseAsync(
                    dto.StudentId,
                    dto.CourseId);

            if (existing != null)
            {
                return "Student already enrolled.";
            }

            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                EnrolledAt = DateTime.Now,
                ProgressPercent = 0
            };

            await _enrollmentRepository
                .AddAsync(enrollment);

            await _enrollmentRepository
                .SaveChangesAsync();

            return "Enrollment successful.";
        }

        public async Task<bool>
            DeleteEnrollmentAsync(int id)
        {
            var enrollment =
                await _enrollmentRepository
                .GetByIdAsync(id);

            if (enrollment == null)
            {
                return false;
            }

            await _enrollmentRepository
                .DeleteAsync(enrollment);

            await _enrollmentRepository
                .SaveChangesAsync();

            return true;
        }
    }
}