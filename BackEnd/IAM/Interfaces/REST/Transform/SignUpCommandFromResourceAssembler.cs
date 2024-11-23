using BackEnd.IAM.Domain.Model.Commands;
using BackEnd.IAM.Interfaces.REST.Resources;

namespace BackEnd.IAM.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}