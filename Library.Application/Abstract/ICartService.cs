using Library.Domain.Abstracts;
using Library.Domain.Models;

namespace Library.Application.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, IProductPrice element);
    void RemoveFromCart(Cart cart, int productId);
    List<CartItem> List(Cart cart);
}
