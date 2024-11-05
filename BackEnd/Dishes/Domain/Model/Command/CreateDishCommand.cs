namespace BackEnd.Dishes;

/// <summary>
/// Command to create a dish
/// </summary>
/// <param name="ChefId">ID of the chef</param>
/// <param name="NameOfDish">Name of the dish</param>
/// <param name="Ingredients">List of ingredients</param>
/// <param name="PreparationSteps">List of preparation steps</param>
/// <param name="Favorite">Indicates if the dish is marked as favorite</param>
public record CreateDishCommand(
    string ChefId,                  // ID del chef que crea el platillo
    string NameOfDish,              // Nombre del platillo
    List<string> Ingredients,        // Lista de ingredientes
    List<string> PreparationSteps,   // Pasos de preparación
    bool Favorite = false            // Default to false for a new dish
);