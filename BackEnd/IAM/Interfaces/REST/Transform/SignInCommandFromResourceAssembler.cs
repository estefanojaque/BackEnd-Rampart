using BackEnd.IAM.Domain.Model.Commands;
using BackEnd.IAM.Interfaces.REST.Resources;

namespace BackEnd.IAM.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}