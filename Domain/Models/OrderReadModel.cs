namespace Domain.Models;

public class OrderReadModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}