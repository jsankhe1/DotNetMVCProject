using Core.Contracts.IRepositories;
using Core.Entities;
using Core.Helpers;
using Core.Models;
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
        var moviesPagedResultSet = _movieRepository.GetMoviesPaged(pageNumber: 1, pageSize: 20);

        var movieModels = moviesPagedResultSet.Items.Select(movieResult => new MovieModel
        {
            Id = movieResult.Id,
            Title = movieResult.Title,
            PosterUrl = movieResult.PosterUrl,
            Description = movieResult.Overview,
        }).ToList();

        var movieCardPagedResults = new PagedResultSet<MovieModel>
        {
            PageSize = moviesPagedResultSet.PageSize,
            TotalCount = moviesPagedResultSet.TotalCount,
            Items = movieModels
        };
        
        
        return View(movieCardPagedResults);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _movieRepository.Insert(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
        
    }
}