using BackEnd.Orders.Domain.Model.Aggregates;
using BackEnd.Orders.Domain.Model.Queries;
using BackEnd.Orders.Domain.Repositories;
using BackEnd.Orders.Domain.Services;

namespace BackEnd.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository)
    : IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.FindAllAsync(); // Uso del método correcto
    }

    public async Task<IEnumerable<Order>> Handle(GetOrderByCustomerIdQuery query)
    {
        return await orderRepository.FindByCustomerIdAsync(query.customerId); // Método corregido 
    }

    public async Task<Order> Handle(GetOrderByIdQuery query)
    {
        var order = await orderRepository.FindByIdAsync(query.orderId);
        if (order == null)
            throw new Exception("Order not found.");

        return order;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrderByStatusQuery query)
    {
        return await orderRepository.FindByStatusAsync(query.status);
    }
}