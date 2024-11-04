using catch_up_platform.Dishes.Interfaces.REST.Resource;

namespace catch_up_platform.Dishes.Interfaces.REST.Transform;

public class CreateDishCommandFromResourceAssembler
{
    public static CreateDishCommand ToCommandFromResource(CreateDishResource resource)
    {
        return new CreateDishCommand(
            resource.ChefName,  // Ahora ChefName es un string
            resource.NameOfDish,
            resource.Ingredients,
            resource.PreparationSteps,
            resource.Favorite ?? false  // Usar valor predeterminado si es null
        );
    }
}