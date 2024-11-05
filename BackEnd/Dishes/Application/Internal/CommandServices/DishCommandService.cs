using BackEnd.Dishes.Domain.Services;
using BackEnd.Shared.Domain.Repositories;

namespace BackEnd.Dishes.Application.Internal.CommandServices
{
    public class DishCommandService : IDishCommandService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DishCommandService(IDishRepository dishRepository, IUnitOfWork unitOfWork)
        {
            _dishRepository = dishRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DishData> Handle(CreateDishCommand command)
        {
            var dish = new DishData(command);

            try
            {
                await _dishRepository.CreateAsync(dish);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                // logger.LogError(e, "Error creating dish.");
                throw new Exception("Error creating dish.", e);
            }

            return dish;
        }

        public async Task<DishData?> Handle(UpdateDishCommand command)
        {
            var dish = await _dishRepository.FindByIdAsync(command.DishId);
            if (dish == null)
            {
                throw new Exception($"Dish with ID {command.DishId} not found.");
            }

            // Variable para rastrear si hubo cambios
            bool hasChanges = false;
            
            if (!string.IsNullOrEmpty(command.NameOfDish) && command.NameOfDish != dish.NameOfDish)
            {
                dish.NameOfDish = command.NameOfDish;
                hasChanges = true;
            }

            if (command.Ingredients != null && !command.Ingredients.SequenceEqual(dish.Ingredients))
            {
                dish.Ingredients = command.Ingredients;
                hasChanges = true;
            }

            if (command.PreparationSteps != null && !command.PreparationSteps.SequenceEqual(dish.PreparationSteps))
            {
                dish.PreparationSteps = command.PreparationSteps;
                hasChanges = true;
            }

            if (command.Favorite.HasValue && command.Favorite.Value != dish.Favorite)
            {
                dish.Favorite = command.Favorite.Value;
                hasChanges = true;
            }

            // Solo guarda si ha habido cambios
            if (hasChanges)
            {
                try
                {
                    await _dishRepository.UpdateAsync(dish);
                    await _unitOfWork.CompleteAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error updating dish: {e.Message}");
                    throw new Exception("Error updating dish.", e);
                }

                return dish; // Devuelve el plato actualizado
            }
            else
            {
                // No se realizaron cambios
                return null;
            }
        }


        public async Task<bool> DeleteDishAsync(int dishId)
        {
            var dish = await _dishRepository.FindByIdAsync(dishId);
            if (dish == null)
                return false;

            try
            {
                await _dishRepository.DeleteAsync(dishId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                // logger.LogError(e, "Error deleting dish.");
                throw new Exception("Error deleting dish.", e);
            }

            return true;
        }
    }
}
