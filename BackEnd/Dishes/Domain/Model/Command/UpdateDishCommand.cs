namespace BackEnd.Dishes;

/// <summary>
/// Command to update a dish's information
/// </summary>
/// <param name="ChefName">Updated name of the chef, if provided</param>
/// <param name="NameOfDish">Updated name of the dish, if provided</param>
/// <param name="Ingredients">Updated list of ingredients, if provided</param>
/// <param name="PreparationSteps">Updated list of preparation steps, if provided</param>
/// <param name="Favorite">Indicates if the dish should be marked as favorite, if updated</param>
public record UpdateDishCommand(
    string? ChefName = null,
    string? NameOfDish = null,
    List<string>? Ingredients = null,
    List<string>? PreparationSteps = null,
    bool? Favorite = null
)
{
    // Internal property to specify the dish ID to update
    internal int DishId { get; init; }

    // Constructor por defecto
    public UpdateDishCommand() : this(null, null, null, null, null)
    {
        DishId = 0; // O un valor predeterminado que tenga sentido
    }

    // Constructor para inicializar el DishId
    public UpdateDishCommand(int dishId) : this()
    {
        DishId = dishId;
    }
}