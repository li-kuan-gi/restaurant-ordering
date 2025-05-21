namespace Server.Orders;

public class CreatedOrderRequest // 定義 CreatedOrderRequest 類別
{
    public required List<OrderItem> Items { get; set; }
}
