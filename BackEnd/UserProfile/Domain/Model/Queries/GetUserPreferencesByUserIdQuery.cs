namespace BackEnd.UserProfile;

/// <summary>
/// Query to retrieve a user's preferences by their unique identifier
/// </summary>
/// <param name="UserId">The ID of the user</param>
public record GetUserPreferencesByUserIdQuery(int UserId);