namespace BackEnd.UserProfile;

/// <summary>
/// Query to retrieve a user profile by its unique identifier
/// </summary>
/// <param name="UserId">The ID of the user</param>
public record GetUserProfileByIdQuery(int UserId);