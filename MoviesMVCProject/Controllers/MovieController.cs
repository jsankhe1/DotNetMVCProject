using Core.Contracts.IRepositories;
using Core.Entities;
using Core.Helpers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesMVCProject.Controllers;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    // GET
    public IActionResult Index(int? genreId, int pageNumber = 1)
    {
        int pageSize = 20; // Movies per page

        //Decide which method from repo to run

        var moviesPagedResultSet = (genreId.HasValue && genreId.Value !=0)
            ? _movieRepository.GetMoviesPagedByGenre(genreId, pageNumber, pageSize)
            : _movieRepository.GetMoviesPaged(pageNumber, pageSize);

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
            CurrentPage = moviesPagedResultSet.CurrentPage, // Now passes the correct page
            Items = movieModels
        };

        ViewBag.Genres = new SelectList(_genreRepository.GetAll().ToList(), "Id", "Name", genreId);
        ViewBag.SelectedGenre = genreId;

        return View(movieCardPagedResults);
    }

    [HttpGet]
    public IActionResult MoviesByGenre(int genreId)
    {
        return RedirectToAction("Index", new { genreId });
    }
    
}