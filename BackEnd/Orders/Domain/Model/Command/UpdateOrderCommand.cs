namespace BackEnd.Orders.Domain.Model.Command;

public record UpdateOrderCommand(
    int? customerId=null ,
    DateTime? orderDate=null,
    DateTime? deliveryDate=null,
    string? paymentMethod=null,
    double? totalAmount=null,
    string? status=null,
    List<string>? dishes=null,
    bool? detailsShown=null
    )
{
    // Solo se asignará internamente, no se mostrará en Swagger
    internal int UserId { get; init; }
};