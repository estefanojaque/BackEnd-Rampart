using BackEnd.IAM.Domain.Model.Aggregates;
using BackEnd.IAM.Domain.Model.Commands;

namespace BackEnd.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);

    Task Handle(SignUpCommand command);
}