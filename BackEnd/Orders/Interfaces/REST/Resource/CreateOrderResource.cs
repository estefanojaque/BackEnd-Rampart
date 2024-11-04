namespace BackEnd.Orders.Interfaces.REST.Resource;



public record CreateOrderResource(
    int customerId,
    DateTime orderDate,
    DateTime deliveryDate,
    string paymentMethod,
    double totalAmount,
    string? status,  // Cambiado a string? para hacerlo opcional
    List<string> dishes,
    bool detailsShown
);