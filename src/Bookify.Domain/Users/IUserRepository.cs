namespace Bookify.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task Add(User user);
        //Task UpdateAsync(User user);
        //Task DeleteAsync(User user);
    }
}