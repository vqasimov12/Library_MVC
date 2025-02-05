using Library.Application.Abstract;
using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Models;
using Library.WebUI.Models;
using Library.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class CartController(ICartService cartService, ICourseService courseService, IBookService bookService, ICartSessionService sessionService) : Controller
{
    private readonly ICartService _cartService = cartService;
    private readonly ICourseService _courseService = courseService;
    private readonly IBookService _bookService = bookService;
    private readonly ICartSessionService _sessionService = sessionService;
    public IActionResult List()
    {
        var model = new CartListViewModel { Cart = _sessionService.GetCart() };
        return View(model);
    }

    public IActionResult AddToCart(int id, string type)
    {
        if (type == "Book")
        {
            var productToBeAdded = _bookService.GetById(id);
            var cart = _sessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _sessionService.SetCart(cart);
            TempData["message"] = string.Format("Your product, {0} was added successully to cart", productToBeAdded.Name);
        }
        else
        {
            var productToBeAdded = _courseService.GetById(id);
            var cart = _sessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _sessionService.SetCart(cart);
            TempData["message"] = string.Format("Your product, {0} was added successully to cart", productToBeAdded.Name);
        }
        return RedirectToAction("Index", type);
    }


    public IActionResult Remove(int id, string name, decimal price)
    {

        IEntity item = _bookService.GetAll().FirstOrDefault(z => z.Name == name && z.Id == id && z.Price == price)!;
        if (item == null)
            item = _courseService.GetAll().FirstOrDefault(z => z.Name == name && z.Id == id && z.Price == price)!;
        if (item == null)
            return RedirectToAction("List");
        var cart = _sessionService.GetCart();
        _cartService.RemoveFromCart(cart, item.Id);
        _sessionService.SetCart(cart);
        TempData["message"] = string.Format("Your product, {0} was removed successully from cart", item.Name);
        return RedirectToAction("List");
    }
    [HttpGet]
    public IActionResult Complete()
    {
        var model = new OrderViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Complete(OrderViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var cart = _sessionService.GetCart();
        cart= new Cart();
        _sessionService.SetCart(cart);

        return RedirectToAction("List");
    }

}