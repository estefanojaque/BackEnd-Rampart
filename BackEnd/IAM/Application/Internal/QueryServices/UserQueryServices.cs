using BackEnd.IAM.Domain.Model.Aggregates;
using BackEnd.IAM.Domain.Model.Queries;
using BackEnd.IAM.Domain.Repositories;
using BackEnd.IAM.Domain.Services;

namespace BackEnd.IAM.Application.Internal.QueryServices;

public class UserQueryServices(IUserRepository userRepository) : IUserQueryServices
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}