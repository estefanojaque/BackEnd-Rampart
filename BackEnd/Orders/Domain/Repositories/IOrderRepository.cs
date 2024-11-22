using BackEnd.Orders.Domain.Model.Aggregates;
using BackEnd.Shared.Domain.Repositories;

namespace BackEnd.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> FindAllAsync();
    
    Task<IEnumerable<Order>> FindByCustomerIdAsync(int customerId);
    
    Task<Order?> FindByOrderIdAsync(int orderId);
    Task<IEnumerable<Order>> FindByStatusAsync(string status );
    
    Task UpdateAsync(Order order);
    
    Task RemoveAsync(Order order);
}