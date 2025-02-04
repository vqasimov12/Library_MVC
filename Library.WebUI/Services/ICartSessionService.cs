using Library.Domain.Models;

namespace Library.WebUI.Services;

public interface ICartSessionService
{
    Cart GetCart();
    void SetCart(Cart cart);
}
