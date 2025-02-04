using Library.Domain.Abstracts;

namespace Library.Domain.Models;

public class CartItem
{
    public IEntity Item { get; set; }
    public int Quantity { get; set; }
}