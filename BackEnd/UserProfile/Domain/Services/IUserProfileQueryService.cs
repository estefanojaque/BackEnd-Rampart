namespace catch_up_platform.UserProfile.Domain.Services;

public interface IUserProfileQueryService
{
    /// <summary>
    /// Retrieves user profile by ID
    /// </summary>
    /// <param name="query">GetUserProfileByIdQuery query</param>
    /// <returns>The UserProfile or null if not found</returns>
    Task<ProfileData?> Handle(GetUserProfileByIdQuery query);

    /// <summary>
    /// Retrieves all user profiles
    /// </summary>
    /// <returns>A list of UserProfiles</returns>
    Task<IEnumerable<ProfileData>> Handle(GetAllUserProfilesQuery query);

    /// <summary>
    /// Retrieves user preferences by user ID
    /// </summary>
    /// <param name="query">GetUserPreferencesByUserIdQuery query</param>
    /// <returns>A list of preferences for the user</returns>
    Task<List<string>> Handle(GetUserPreferencesByUserIdQuery query);

    /// <summary>
    /// Retrieves user profiles by specific food preference
    /// </summary>
    /// <param name="query">GetUserProfilesByPreferenceQuery query</param>
    /// <returns>A list of UserProfiles that match the specified preference</returns>
    Task<IEnumerable<ProfileData>> Handle(GetUserProfilesByPreferenceQuery query);
}