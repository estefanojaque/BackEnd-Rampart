using BackEnd.IAM.Interfaces.Resources;

namespace BackEnd.IAM.Interfaces.Transform;

public class AuthenticatedUserResourceFromEntotyAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}