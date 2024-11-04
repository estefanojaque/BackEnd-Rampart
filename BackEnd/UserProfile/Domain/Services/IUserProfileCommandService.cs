namespace catch_up_platform.UserProfile.Domain.Services;

public interface IUserProfileCommandService
{
    /// <summary>
    /// Handles the CreateUserProfileCommand.
    /// </summary>
    /// <remarks>
    /// This method will handle the CreateUserProfileCommand and return the created UserProfile.
    /// </remarks>
    /// <param name="command">CreateUserProfileCommand command</param>
    /// <returns>The created UserProfile or null if the operation failed.</returns>
    Task<ProfileData?> Handle(CreateUserProfileCommand command);

    /// <summary>
    /// Handles the UpdateUserProfileCommand.
    /// </summary>
    /// <remarks>
    /// This method will update the UserProfile identified by userId.
    /// </remarks>
    /// <param name="command">UpdateUserProfileCommand command</param>
    /// <returns>The updated UserProfile or null if the operation failed.</returns>
    Task<ProfileData?> Handle(UpdateUserProfileCommand command);

    /// <summary>
    /// Updates user preferences for a user profile.
    /// </summary>
    /// <remarks>
    /// This method will update the preferences for a specific user profile identified by userId.
    /// </remarks>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="preferences">List of preferences to be updated.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    Task UpdatePreferencesAsync(int userId, List<string> preferences);
    
    /// <summary>
    /// Deletes the user profile identified by the specified ID.
    /// </summary>
    /// <param name="id">The ID of the user profile to delete.</param>
    /// <returns>A Task representing the asynchronous operation, which returns true if the profile was deleted successfully, otherwise false.</returns>
    Task<bool> DeleteUserProfileAsync(int id);
}