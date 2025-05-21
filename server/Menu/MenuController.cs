namespace Server.Menu;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public IEnumerable<MenuItem> Get()
    {
        // 返回模擬菜單數據
        return
        [
            new() { Id = 1, Name = "Burger", Description = "Delicious burger", Price = 9.99f },
            new() { Id = 2, Name = "Pizza", Description = "Cheesy pizza", Price = 12.99f }
        ];
    }
}
