using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MoviesMVCProject.Controllers;

public class CastController : Controller
{
    private readonly CastRepository _castRepository;

    public CastController(CastRepository _castRepository)
    {
        this._castRepository = _castRepository;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}