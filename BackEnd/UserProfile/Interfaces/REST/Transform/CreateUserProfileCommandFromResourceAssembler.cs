using BackEnd.UserProfile.Interfaces.REST.Resource;

namespace BackEnd.UserProfile.Interfaces.REST.Transform;

public class CreateUserProfileCommandFromResourceAssembler
{
    public static CreateUserProfileCommand ToCommandFromResource(CreateUserProfileResource resource)
    {
        return new CreateUserProfileCommand(resource.Photo, resource.Name, resource.Email, resource.BirthDate, resource.Address, resource.PaymentMethod, resource.CardNumber, resource.YapeNumber, resource.CashPayment, resource.Preferences);
    }
}