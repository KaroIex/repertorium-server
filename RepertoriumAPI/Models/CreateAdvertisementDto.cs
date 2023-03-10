namespace RepertoriumAPI.Models;

public class CreateAdvertisementDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsNegotiable { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}