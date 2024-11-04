namespace BackEnd.Dishes.Interfaces.REST.Resource;

/// <summary>
/// Resource for creating a new dish.
/// </summary>
public record CreateDishResource(
    string ChefName,  // Cambiado a string para que coincida con CreateDishCommand
    string NameOfDish,  // Nombre del platillo
    List<string> Ingredients,  // Lista de ingredientes
    List<string> PreparationSteps,  // Pasos de preparación
    bool? Favorite  // Indica si es un platillo favorito, opcional
);