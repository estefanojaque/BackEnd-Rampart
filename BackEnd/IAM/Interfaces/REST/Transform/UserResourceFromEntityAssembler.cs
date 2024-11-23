using BackEnd.IAM.Interfaces.Resources;

namespace BackEnd.IAM.Interfaces.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}