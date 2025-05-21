namespace Server.Orders;

public class Order // 定義 Order 類別
{
    public int Id { get; set; }
    public required List<OrderItem> Items { get; set; }
    public float Total { get; set; }
    public required string Status { get; set; }
}
