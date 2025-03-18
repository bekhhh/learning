namespace BusinessLogic;

    public interface IUserService
    {
        Task CreateAsync(string name, string email, CancellationToken cancellationToken = default);
        Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, string newName, string email, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
