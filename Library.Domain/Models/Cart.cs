using Library.Domain.Abstracts;

namespace Library.Domain.Models;

public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public decimal Total
    {
        get => Items.Sum(i => (i.Item as IProductPrice)?.Price * i.Quantity ?? 0);
    }
}
