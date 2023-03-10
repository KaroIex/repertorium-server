namespace RepertoriumAPI.Entities;

public class Image
{
    public int Id { get; set; }
    public int AdvertisementId { get; set; }
    public string FileName { get; set; }

    public virtual Advertisement Advertisement { get; set; }
}