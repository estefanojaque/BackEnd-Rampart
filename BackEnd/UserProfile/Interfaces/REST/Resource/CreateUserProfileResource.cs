namespace catch_up_platform.UserProfile.Interfaces.REST.Resource;

/// <summary>
/// Resource for creating a new user profile.
/// </summary>
public record CreateUserProfileResource(
    string Photo,
    string Name,
    string Email,
    DateTime BirthDate,
    string Address,
    string PaymentMethod,
    string? CardNumber,  // Cambiado a string? para hacerlo opcional
    string? YapeNumber,  // Cambiado a string? para hacerlo opcional
    bool CashPayment,
    List<string> Preferences
);
