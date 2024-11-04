using catch_up_platform.Shared.Domain.Repositories;

namespace catch_up_platform.UserProfile;

/// <summary>
/// Repository interface for user profile entity
/// </summary>
public interface IUserProfileRepository : IBaseRepository<ProfileData>
{
    /// <summary>
    /// Gets a user profile by user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>The user profile or null if not found.</returns>
    Task<ProfileData?> FindByIdAsync(int userId);
    
    /// <summary>
    /// Gets all user profiles.
    /// </summary>
    /// <returns>List of user profiles.</returns>
    Task<IEnumerable<ProfileData>> GetAllAsync();

    /// <summary>
    /// Updates the preferences for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="preferences">The new list of preferences.</param>
    Task UpdatePreferencesAsync(int userId, List<string> preferences);

    /// <summary>
    /// Gets the preferences for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>List of preferences for the user or an empty list if not found.</returns>
    Task<List<string>> GetPreferencesByUserIdAsync(int userId);
    
    /// <summary>
    /// Gets user profiles that match specified preferences.
    /// </summary>
    /// <param name="preferences">List of preferences to filter user profiles.</param>
    /// <returns>List of user profiles matching the specified preferences.</returns>
    Task<IEnumerable<ProfileData>> GetUserProfilesByPreferencesAsync(List<string> preferences);
    
    /// <summary>
    /// Finds a user profile by email.
    /// </summary>
    /// <param name="email">The email of the user profile.</param>
    /// <returns>The user profile or null if not found.</returns>
    Task<ProfileData?> FindByEmailAsync(string email);
    
    /// <summary>
    /// Updates the user profile.
    /// </summary>
    /// <param name="profile">The user profile to update.</param>
    Task UpdateAsync(ProfileData profile);
    
    /// <summary>
    /// Removes a user profile.
    /// </summary>
    /// <param name="profile">The user profile to remove.</param>
    Task RemoveAsync(ProfileData profile);
}
