using Library.Application.Abstract;
using Library.Domain.Abstracts;
using Library.Domain.Models;

namespace Library.Application.Concrete;

public class CartService : ICartService
{
    public void AddToCart(Cart cart, IEntity element)
    {
        CartItem cartItem = cart.Items.FirstOrDefault(x => x.Item.Id == element.Id)!;
        if (cartItem != null)
            cartItem.Quantity++;
        else
            cart.Items.Add(new CartItem { Quantity = 1, Item = element });
    }

    public List<CartItem> List(Cart cart) => cart.Items;

    public void RemoveFromCart(Cart cart, int productId) => cart.Items.Remove(cart.Items.FirstOrDefault(x => x.Item.Id== productId)!);
}