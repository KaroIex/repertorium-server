namespace RepertoriumAPI.Models;

public class AdvertisementPagedDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsNegotiable { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}