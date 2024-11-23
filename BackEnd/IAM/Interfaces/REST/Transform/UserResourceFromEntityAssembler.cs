using BackEnd.IAM.Domain.Model.Aggregates;
using BackEnd.IAM.Interfaces.REST.Resources;

namespace BackEnd.IAM.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}