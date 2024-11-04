namespace BackEnd.Orders.Domain.Model.Command;

public record CreateOrderCommand(
    int customerId,
    DateTime orderDate,
    DateTime deliveryDate,
    string paymentMethod,
    double totalAmount,
    string status,
    List<string> dishes,
    bool detailsShown
    );