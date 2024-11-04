namespace catch_up_platform.Dishes.Interfaces.REST.Resource;

/// <summary>
/// Resource representing a dish.
/// </summary>
public record DishResource(
    string ChefId,                   // ID del chef
    string NameOfDish,               // Nombre del platillo
    List<string> Ingredients,         // Lista de ingredientes
    List<string> PreparationSteps,    // Pasos de preparación
    bool? Favorite                    // Indica si es un platillo favorito, opcional
);