using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace catch_up_platform.UserProfile.Infrastructure.Repositories;

public class UserProfileRepository(AppDbContext context) 
    : BaseRepository<ProfileData>(context), IUserProfileRepository
{
    public async Task<ProfileData?> GetByIdAsync(int userId)
    {
        return await Context.Set<ProfileData>().FindAsync(userId);
    }

    public async Task<IEnumerable<ProfileData>> GetAllAsync()
    {
        return await Context.Set<ProfileData>().ToListAsync();
    }

    public async Task UpdatePreferencesAsync(int userId, List<string> preferences)
    {
        var userProfile = await GetByIdAsync(userId);
        if (userProfile != null)
        {
            userProfile.Preferences = preferences; // Asignar directamente la lista de preferencias
            await Context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetPreferencesByUserIdAsync(int userId)
    {
        var userProfile = await GetByIdAsync(userId);
        return userProfile?.Preferences ?? new List<string>();     
    }

    public async Task<IEnumerable<ProfileData>> GetUserProfilesByPreferencesAsync(List<string> preferences)
    {
        return await Context.Set<ProfileData>()
            .Where(up => up.Preferences.Any(p => preferences.Contains(p))) // Asumiendo que Preferences es List<string>
            .ToListAsync();
    }

    
    public async Task<ProfileData?> FindByEmailAsync(string email)
    {
        return await Context.Set<ProfileData>()
            .FirstOrDefaultAsync(up => up.Email == email);
    }

    public async Task UpdateAsync(ProfileData profile)
    {
        Context.Set<ProfileData>().Update(profile);
        await Context.SaveChangesAsync();
    }
    
    public async Task RemoveAsync(ProfileData profile)
    {
        Context.Set<ProfileData>().Remove(profile);
        await Context.SaveChangesAsync();
    }
}