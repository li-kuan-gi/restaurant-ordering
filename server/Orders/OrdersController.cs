namespace Server.Orders;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrdersController(ILogger<OrdersController> logger) : ControllerBase
{
    private readonly ILogger<OrdersController> _logger = logger;

    [HttpPost]
    public OrderConfirmation CreateOrder(CreatedOrderRequest orderRequest)
    {
        // 處理創建訂單邏輯 (目前返回模擬確認)
        _logger.LogInformation("Received order request with {Count} items.", orderRequest.Items.Count);
        return new OrderConfirmation { OrderId = 101, Message = "Order created successfully (simulated)." };
    }

    [HttpGet]
    public IEnumerable<Order> Get()
    {
        // 返回模擬訂單列表數據
        return
        [
            new() {
                Id = 201,
                Items = [
                    new OrderItem { MenuItemId = 1, Quantity = 2 }
                ],
                Total = 19.98f,
                Status = "pending",
            },
            new() {
                Id = 202,
                Items = [
                    new() { MenuItemId = 2, Quantity = 1 }
                ],
                Total = 12.99f,
                Status = "processing",
            },
        ];
    }
}
