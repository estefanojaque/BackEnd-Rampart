using BackEnd.UserProfile.Domain.Services;

namespace BackEnd.UserProfile.Application.Internal.QueryServices
{
    public class UserProfileQueryService : IUserProfileQueryService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileQueryService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<IEnumerable<ProfileData>> Handle(GetAllUserProfilesQuery query)
        {
            return await _userProfileRepository.GetAllAsync(); // Uso del método correcto
        }

        public async Task<ProfileData> Handle(GetUserProfileByIdQuery query)
        {
            var profile = await _userProfileRepository.FindByIdAsync(query.UserId);
            if (profile == null)
                throw new Exception("User profile not found.");

            return profile;
        }

        public async Task<List<string>> Handle(GetUserPreferencesByUserIdQuery query)
        {
            return await _userProfileRepository.GetPreferencesByUserIdAsync(query.UserId); // Método corregido
        }

        public async Task<IEnumerable<ProfileData>> Handle(GetUserProfilesByPreferenceQuery query)
        {
            return await _userProfileRepository.GetUserProfilesByPreferencesAsync(query.Preferences);
        }
    }
}