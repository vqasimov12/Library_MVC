using Library.Application.Abstract;
using Library.Domain.Entities;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;

    public IActionResult Index(int page = 1)
    {
        var users = _userService.GetAll();
        int pageSize = 6;
        var pagedUsers = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var model = new UserViewModel
        {
            Users = pagedUsers,
            PageCount = (int)Math.Ceiling(users.Count / (double)pageSize),
            PageSize = pageSize,
            CurrentPage = page,
            Type = "User"
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Add(int id = -1)
    {
        var model = new UserAddViewModel { };
        if (id > 0)
            model.User = _userService.GetById(id);
        else
            model.User = new User();
        return View(model);
    }
    [HttpPost]
    public IActionResult Add(UserAddViewModel model, IFormFile? ProfileImageFile)
    {
        model.ProfileImage ??= "DefaultUser.png";

        if (ModelState.IsValid)
        {
            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                string fileExtension = Path.GetExtension(ProfileImageFile.FileName);
                string uniqueFilename = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uniqueFilename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    ProfileImageFile.CopyTo(stream);

                model.User.ProfileImage = uniqueFilename;
            }


            if (model.User.Id > 0)
                _userService.Update(model.User);
            else
                _userService.Add(model.User);

            return RedirectToAction("Index");
        }
        else return View(model);
    }

    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return RedirectToAction("Index");
    }
}