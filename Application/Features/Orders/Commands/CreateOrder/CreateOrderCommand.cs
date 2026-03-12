namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand
{
    public string CustomerName { get; set; }
    public decimal TotalPrice { get; set; }
}