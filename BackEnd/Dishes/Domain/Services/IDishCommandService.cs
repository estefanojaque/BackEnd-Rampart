namespace BackEnd.Dishes.Domain.Services
{
    public interface IDishCommandService
    {
        /// <summary>
        /// Handles the CreateDishCommand.
        /// </summary>
        /// <remarks>
        /// This method will handle the CreateDishCommand and return the created Dish.
        /// </remarks>
        /// <param name="command">CreateDishCommand command</param>
        /// <returns>The created Dish or null if the operation failed.</returns>
        Task<DishData?> Handle(CreateDishCommand command);

        /// <summary>
        /// Handles the UpdateDishCommand.
        /// </summary>
        /// <remarks>
        /// This method will update the Dish identified by dishId.
        /// </remarks>
        /// <param name="command">UpdateDishCommand command</param>
        /// <returns>The updated Dish or null if the operation failed.</returns>
        Task<DishData?> Handle(UpdateDishCommand command);

        /// <summary>
        /// Deletes the dish identified by the specified ID.
        /// </summary>
        /// <param name="dishId">The ID of the dish to delete.</param>
        /// <returns>A Task representing the asynchronous operation, which returns true if the dish was deleted successfully, otherwise false.</returns>
        Task<bool> DeleteDishAsync(int dishId);
    }
}