using BackEnd.Orders.Domain.Model.Aggregates;

namespace BackEnd.Orders.Interfaces.REST.Transform.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
    {
        // Asegúrate de que entity.Preferences sea de tipo List<UserPreference>
        var dishes = entity.dishes; // No es necesario convertir, ya es List<string>

        return new OrderResource(
            entity.Id,
            entity.customerId,
            entity.orderDate,
            entity.deliveryDate,
            entity.paymentMethod,
            entity.totalAmount,
            entity.status,
            dishes,
            entity.detailsShown
        );
    }
}