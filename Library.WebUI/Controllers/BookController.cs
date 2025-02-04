using Library.Application.Abstract;
using Library.Application.Concrete;
using Library.Domain.Entities;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class BookController(IBookService bookService) : Controller
{
    private readonly IBookService _bookService = bookService;

    public IActionResult Index(int page=1)
    {
        var books = _bookService.GetAll();
        int pageSize = 3;
        var pagedBooks = books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var model = new BookListViewModel
        {
            Books = pagedBooks,
            PageCount = (int)Math.Ceiling(books.Count / (double)pageSize),
            PageSize = pageSize,
            CurrentPage = page,
            Type="Book"
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Add(int id = -1)
    {
        var model = new BookAddViewModel { };
        if (id > 0)
            model.Book= _bookService.GetById(id);
        else
            model.Book = new Book();
        return View(model);
    }
    [HttpPost]
    public IActionResult Add(BookAddViewModel model, IFormFile? BookImageFile)
    {

        if (ModelState.IsValid)
        {
            if (BookImageFile != null && BookImageFile.Length > 0)
            {
                string fileExtension = Path.GetExtension(BookImageFile.FileName);
                string uniqueFilename = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uniqueFilename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    BookImageFile.CopyTo(stream);

                model.Book.BookImage = uniqueFilename;
            }


            if (model.Book.Id > 0)
                _bookService.Update(model.Book);
            else
                _bookService.Add(model.Book);

            return RedirectToAction("Index");
        }
        else return View(model);
    }

    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var model = new BookDetailViewModel
        {
            Book = _bookService.GetById(id),
        };

        return View(model);
    }
}