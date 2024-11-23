using BackEnd.IAM.Domain.Model.Aggregates;
using BackEnd.Shared.Domain.Repositories;

namespace BackEnd.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}