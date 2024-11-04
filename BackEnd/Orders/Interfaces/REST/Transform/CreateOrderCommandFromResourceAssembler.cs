using BackEnd.Orders.Domain.Model.Command;
using BackEnd.Orders.Interfaces.REST.Resource;

namespace BackEnd.Orders.Interfaces.REST.Transform.Transform;

public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(resource.customerId, resource.orderDate, resource.deliveryDate, resource.paymentMethod, resource.totalAmount, resource.status, resource.dishes, resource.detailsShown);
    }
}