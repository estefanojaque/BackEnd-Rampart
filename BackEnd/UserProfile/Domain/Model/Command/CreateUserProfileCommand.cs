namespace BackEnd.UserProfile;

/// <summary>
/// Command to create a user profile
/// </summary>
/// <param name="Photo">URL of the user's photo</param>
/// <param name="Name">Name of the user</param>
/// <param name="Email">Email address of the user</param>
/// <param name="BirthDate">Birthdate of the user</param>
/// <param name="Address">Physical address of the user</param>
/// <param name="PaymentMethod">Preferred payment method</param>
/// <param name="CardNumber">Card number if applicable</param>
/// <param name="YapeNumber">Yape number if applicable</param>
/// <param name="CashPayment">Indicates if cash payment is accepted</param>
/// <param name="Preferences">List of user preferences</param>
public record CreateUserProfileCommand(
    string Photo,
    string Name,
    string Email,
    DateTime BirthDate,
    string Address,
    string PaymentMethod,
    string CardNumber,
    string YapeNumber,
    bool CashPayment,
    List<string> Preferences
);