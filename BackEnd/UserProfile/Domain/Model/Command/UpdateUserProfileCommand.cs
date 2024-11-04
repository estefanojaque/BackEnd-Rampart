namespace BackEnd.UserProfile;

/// <summary>
/// Command to update a user profile's information
/// </summary>
/// <param name="Photo">Profile photo URL or base64 encoded image, if updated</param>
/// <param name="Name">Updated name of the user, if provided</param>
/// <param name="Email">Updated email of the user, if provided</param>
/// <param name="BirthDate">Updated birthdate of the user, if provided</param>
/// <param name="Address">Updated address of the user, if provided</param>
/// <param name="PaymentMethod">Updated preferred payment method, if provided</param>
/// <param name="CardNumber">Updated card number, if applicable</param>
/// <param name="YapeNumber">Updated Yape number, if applicable</param>
/// <param name="CashPayment">Indicates if cash payment is accepted, if updated</param>
/// <param name="Preferences">Updated list of preferences, if provided</param>
public record UpdateUserProfileCommand(
    string? Photo = null,
    string? Name = null,
    string? Email = null,
    DateTime? BirthDate = null,
    string? Address = null,
    string? PaymentMethod = null,
    string? CardNumber = null,
    string? YapeNumber = null,
    bool? CashPayment = null,
    List<string>? Preferences = null
)
{
    // Solo se asignará internamente, no se mostrará en Swagger
    internal int UserId { get; init; }
};