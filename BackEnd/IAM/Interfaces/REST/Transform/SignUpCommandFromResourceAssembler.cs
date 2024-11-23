using BackEnd.IAM.Interfaces.Resources;

namespace BackEnd.IAM.Interfaces.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}