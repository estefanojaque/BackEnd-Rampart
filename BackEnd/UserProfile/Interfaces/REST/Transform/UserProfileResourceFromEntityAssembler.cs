using catch_up_platform.UserProfile.Interfaces.REST.Resource;

namespace catch_up_platform.UserProfile.Interfaces.REST.Transform;

public static class UserProfileResourceFromEntityAssembler
{
    public static UserProfileResource ToResourceFromEntity(ProfileData entity)
    {
        // Asegúrate de que entity.Preferences sea de tipo List<UserPreference>
        var preferences = entity.Preferences; // No es necesario convertir, ya es List<string>

        return new UserProfileResource(
            entity.Id,
            entity.Photo,
            entity.Name,
            entity.Email,
            entity.BirthDate,
            entity.Address,
            entity.PaymentMethod,
            entity.CardNumber,
            entity.YapeNumber,
            entity.CashPayment,
            preferences // Usa la lista convertida de las preferencias
        );
    }
}