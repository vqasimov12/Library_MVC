using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
