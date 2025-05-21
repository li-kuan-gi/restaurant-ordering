namespace Server.Orders;

public class OrderConfirmation // 定義 OrderConfirmation 類別
{
    public int OrderId { get; set; }
    public required string Message { get; set; }
}
