using System.Text.Json;
using BackEnd.Orders.Domain.Model.Command; //jsonserialaizer

namespace BackEnd.Orders.Domain.Model.Aggregates;

public class Order
{
    
    public int Id { get; set; }
    public int customerId { get; set; }
    public DateTime orderDate { get; set; }
    public DateTime deliveryDate { get; set; }
    public string paymentMethod { get; set; } = string.Empty;
    public double totalAmount { get; set; }
    public string status { get; set; }= string.Empty;
    
    public string PreferencesJson { get; set; } = string.Empty;
    
   
    public List<string> dishes 
    { 
        get => string.IsNullOrEmpty(PreferencesJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PreferencesJson);
        set => PreferencesJson = JsonSerializer.Serialize(value);
    }
    
    public bool detailsShown { get; set; }
    
    //lo crea vacio
    protected Order() { }
    
    //lo crea con el command
    public Order(CreateOrderCommand command)
    {
        customerId = command.customerId;
        orderDate = command.orderDate;
        deliveryDate = command.deliveryDate;
        paymentMethod = command.paymentMethod;
        totalAmount = command.totalAmount;
        status = command.status;
        dishes = command.dishes;
        detailsShown = command.detailsShown;
    }
}