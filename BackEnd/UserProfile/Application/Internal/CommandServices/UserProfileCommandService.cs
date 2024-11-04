using BackEnd.UserProfile.Domain.Services;
using BackEnd.Shared.Domain.Repositories;

namespace BackEnd.UserProfile.Application.Internal.CommandServices
{
    public class UserProfileCommandService : IUserProfileCommandService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileCommandService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileData?> Handle(CreateUserProfileCommand command)
        {
            var existingProfile = await _userProfileRepository.FindByEmailAsync(command.Email);
            if (existingProfile != null)
                throw new Exception("User profile with this email already exists.");

            var userProfile = new ProfileData(command);
            try
            {
                await _userProfileRepository.AddAsync(userProfile);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return userProfile;
        }

        public async Task<ProfileData?> Handle(UpdateUserProfileCommand command)
        {
            var profile = await _userProfileRepository.FindByIdAsync(command.UserId);
            if (profile == null)
                throw new Exception("User profile not found.");

            // Actualiza las propiedades del perfil según el comando
            if (command.Photo != null)
            {
                profile.Photo = command.Photo; // Actualiza la propiedad Photo
            }

            if (command.Name != null)
            {
                profile.Name = command.Name;
            }

            if (command.Email != null)
            {
                profile.Email = command.Email;
            }

            if (command.BirthDate.HasValue)
            {
                profile.BirthDate = command.BirthDate.Value;
            }

            if (command.Address != null)
            {
                profile.Address = command.Address;
            }

            if (command.PaymentMethod != null)
            {
                profile.PaymentMethod = command.PaymentMethod;
            }

            if (command.CardNumber != null)
            {
                profile.CardNumber = command.CardNumber;
            }

            if (command.YapeNumber != null)
            {
                profile.YapeNumber = command.YapeNumber;
            }

            if (command.CashPayment.HasValue)
            {
                profile.CashPayment = command.CashPayment.Value;
            }

            if (command.Preferences != null)
            {
                profile.Preferences = command.Preferences; // Asignar directamente la lista de preferencias
            }

            try
            {
                await _userProfileRepository.UpdateAsync(profile);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return profile; // Devuelve el perfil actualizado
        }


        public async Task UpdatePreferencesAsync(int userId, List<string> preferences)
        {
            var profile = await _userProfileRepository.FindByIdAsync(userId);
            if (profile != null)
            {
                // Asigna directamente la lista de preferencias
                profile.Preferences = preferences;

                try
                {
                    await _userProfileRepository.UpdateAsync(profile);
                    await _unitOfWork.CompleteAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                throw new Exception("User profile not found.");
            }
        }
        
        public async Task<bool> DeleteUserProfileAsync(int id)
        {
            var profile = await _userProfileRepository.FindByIdAsync(id);
            if (profile == null)
            {
                return false; // No se encontró el perfil
            }

            try
            {
                await _userProfileRepository.RemoveAsync(profile); // Eliminar el perfil del repositorio
                await _unitOfWork.CompleteAsync(); // Completar la unidad de trabajo
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true; // Se eliminó correctamente
        }
        
        public async Task<List<ProfileData>> GetUserProfilesByPreferencesAsync(List<string> preferences)
        {
            var allProfiles = await _userProfileRepository.GetAllAsync();

            // Cambia aquí para evaluar la consulta en el cliente
            var matchingProfiles = allProfiles
                .Where(profile => profile.Preferences.Any(pref => preferences.Contains(pref)))
                .ToList();

            return matchingProfiles;
        }

    }
}
