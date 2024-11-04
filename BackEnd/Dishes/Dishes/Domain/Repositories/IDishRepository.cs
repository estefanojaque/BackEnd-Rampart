using catch_up_platform.Shared.Domain.Repositories;

namespace catch_up_platform.Dishes;

/// <summary>
/// Repository interface for dish entity
/// </summary>
public interface IDishRepository : IBaseRepository<DishData>
{
    /// <summary>
    /// Gets a dish by its ID.
    /// </summary>
    /// <param name="dishId">The ID of the dish.</param>
    /// <returns>The dish or null if not found.</returns>
    Task<DishData?> FindByIdAsync(int dishId);

    /// <summary>
    /// Gets all dishes.
    /// </summary>
    /// <returns>List of all dishes.</returns>
    Task<IEnumerable<DishData>> GetAllAsync();

    /// <summary>
    /// Creates a new dish.
    /// </summary>
    /// <param name="dish">The dish to create.</param>
    Task CreateAsync(DishData dish);

    /// <summary>
    /// Updates an existing dish.
    /// </summary>
    /// <param name="dish">The dish with updated data.</param>
    Task UpdateAsync(DishData dish);

    /// <summary>
    /// Deletes a dish by ID.
    /// </summary>
    /// <param name="dishId">The ID of the dish to delete.</param>
    Task DeleteAsync(int dishId);
}