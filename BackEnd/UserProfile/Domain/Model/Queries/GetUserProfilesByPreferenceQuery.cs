namespace catch_up_platform.UserProfile;

/// <summary>
/// Query to get user profiles by a specific preference
/// </summary>
/// <summary>
/// Query to retrieve user profiles by specific preferences
/// </summary>
/// <param name="Preferences">List of user preferences to filter profiles</param>
public record GetUserProfilesByPreferenceQuery(List<string> Preferences);