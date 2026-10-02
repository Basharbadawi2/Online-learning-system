using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUserRepository _userRepository;

        public InstructorService(
            IInstructorRepository instructorRepository,
            IUserRepository userRepository)
        {
            _instructorRepository = instructorRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task<Instructor?> GetInstructorByUserIdAsync(int userId)
        {
            return await _instructorRepository.GetByUserIdAsync(userId);
        }

        public async Task<string> CreateInstructorAsync(
            int userId,
            string? bio,
            string? specialization)
        {
            // Check that the user exists
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return "User not found.";
            }

            // Check that the user has Instructor role
            if (user.RoleId != 2)
            {
                return "User does not have the Instructor role.";
            }

            // Check if this user is already an instructor
            var existingInstructor =
                await _instructorRepository.GetByUserIdAsync(userId);

            if (existingInstructor != null)
            {
                return "This user is already an instructor.";
            }

            var instructor = new Instructor
            {
                UserId = userId,
                Bio = bio,
                Specialization = specialization
            };

            await _instructorRepository.AddAsync(instructor);
            await _instructorRepository.SaveChangesAsync();

            return "Instructor created successfully.";
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructor =
                await _instructorRepository.GetByIdAsync(id);

            if (instructor == null)
            {
                return false;
            }

            await _instructorRepository.DeleteAsync(instructor);
            await _instructorRepository.SaveChangesAsync();

            return true;
        }
    }
}