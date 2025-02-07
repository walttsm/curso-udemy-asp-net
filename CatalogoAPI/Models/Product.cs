namespace CatalogoAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal price { get; set; }
    public string? ImageUrl { get; set; }
    public float Stock { get; set; }
    public DateTime CreatedAt { get; set; }
}
