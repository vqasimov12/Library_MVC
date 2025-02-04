using Library.Application.Abstract;
using Library.Application.Concrete;
using Library.Domain.Entities;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

public class CourseController(ICourseService courseService) : Controller
{
    private readonly ICourseService _courseService = courseService;

    public IActionResult Index(int page=1)
    {
        var courses = _courseService.GetAll();
        int pageSize = 3;
        var pagedCouses = courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var model = new CourseViewModel
        {
            Courses = pagedCouses,
            PageCount = (int)Math.Ceiling(courses.Count / (double)pageSize),
            PageSize = pageSize,
            CurrentPage = page,
            Type = "Course"
        };
        return View(model);
    }


    [HttpGet]
    public IActionResult Add(int id = -1)
    {
        var model = new CourseAddViewModel { };
        if (id > 0)
            model.Course = _courseService.GetById(id);
        else
            model.Course = new Course();
        return View(model);
    }
    [HttpPost]
    public IActionResult Add(CourseAddViewModel model, IFormFile? CourseImageFile)
    {

        if (ModelState.IsValid)
        {
            if (CourseImageFile != null && CourseImageFile.Length > 0)
            {
                string fileExtension = Path.GetExtension(CourseImageFile.FileName);
                string uniqueFilename = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uniqueFilename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    CourseImageFile.CopyTo(stream);

                model.Course.CourseImage = uniqueFilename;
            }


            if (model.Course.Id > 0)
                _courseService.Update(model.Course);
            else
                _courseService.Add(model.Course);

            return RedirectToAction("Index");
        }
        else return View(model);
    }
    public IActionResult Delete(int id)
    {
        _courseService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var model = new CourseDetailViewModel
        {
            Course = _courseService.GetById(id),
        };

        return View(model);
    }
}