using Core.Contracts.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MoviesMVCProject.Controllers;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }
}