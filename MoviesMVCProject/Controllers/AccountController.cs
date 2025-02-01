using Microsoft.AspNetCore.Mvc;

namespace MoviesMVCProject.Controllers;

public class AccountController : Controller
{ 
    // GET
    public IActionResult Index()
    {
        return View();
    }
}