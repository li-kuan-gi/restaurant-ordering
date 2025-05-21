namespace Server.Menu;

public class MenuItem // 定義 MenuItem 類別，與 api-spec.yaml 中的 Schema 對應
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public float Price { get; set; }
}
