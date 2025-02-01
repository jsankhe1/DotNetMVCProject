using Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MoviesMVCProject.Controllers;

public class AdminController : Controller
{

 
    // GET
    public IActionResult Index()
    {
        return View();
    }
}