using Core.Contracts.IRepositories;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MoviesMVCProject.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}