using DataAccess;

namespace BusinessLogic;

    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task CreateAsync(string name, string email, CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                Name = name,
                Email = email
            };
            await userRepository.CreateAsync(user, cancellationToken);
        }

        public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);
            if (user is null)
            {
                throw new Exception("User not null");
            }

            return user.Name;
        }

        public async Task UpdateAsync(int id, string newName, string email, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);
            if (user is null)
            {
                throw new Exception("User not null");
            }

            user.Name = newName;
            await userRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);
            if (user is null)
            {
                throw new Exception("User not null");
            }

            await userRepository.DeleteAsync(user, cancellationToken);
        }
    }