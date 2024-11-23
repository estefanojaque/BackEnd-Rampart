using BackEnd.IAM.Domain.Model.Aggregates;
using BackEnd.IAM.Domain.Model.Queries;

namespace BackEnd.IAM.Domain.Services;

public interface IUserQueryServices
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}