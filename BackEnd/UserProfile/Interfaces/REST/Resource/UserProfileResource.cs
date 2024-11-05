namespace BackEnd.UserProfile.Interfaces.REST.Resource;

/// <summary>
/// Resource representing a user profile.
/// </summary>
public record UserProfileResource(
    int Id,
    string Photo,
    string Name,
    string Email,
    DateTime BirthDate,
    string Address,
    string PaymentMethod,
    string? CardNumber,
    string? YapeNumber,
    bool CashPayment,
    List<string> Preferences
);