using BackEnd.Shared.Domain.Repositories;

namespace BackEnd.IAM;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}