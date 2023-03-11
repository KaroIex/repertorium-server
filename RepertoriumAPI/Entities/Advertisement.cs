namespace RepertoriumAPI.Entities;

public class Advertisement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsNegotiable { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    //public int UserId { get; set; }

    public virtual Category Category { get; set; }

    //public virtual User User { get; set; }
    public virtual ICollection<Image> Images { get; set; }
    //public virtual ICollection<Favorite> Favorites { get; set; }
    //public virtual ICollection<Message> Messages { get; set; }
}