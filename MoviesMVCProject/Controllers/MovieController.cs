using Core.Contracts.IRepositories;
using Core.Entities;
using Core.Helpers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesMVCProject.Models;

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

        var movieCardModels = moviesPagedResultSet.Items.Select(movieResult => new MovieCardModel()
        {
            Id = movieResult.Id,
            Title = movieResult.Title,
            PosterUrl = movieResult.PosterUrl,
            Description = movieResult.Overview,
        }).ToList();

        var movieCardPagedResults = new PagedResultSet<MovieCardModel>
        {
            PageSize = moviesPagedResultSet.PageSize,
            TotalCount = moviesPagedResultSet.TotalCount,
            CurrentPage = moviesPagedResultSet.CurrentPage, // Now passes the correct page
            Items = movieCardModels
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

    public IActionResult MoviePage(int movieId)
    {

        var movie = _movieRepository.GetById(movieId);
        if (movie == null)
        {
            return NotFound();
        }
        // error checking for future if movie detailes somehow don't exist.
        
        var casts = _movieRepository.GetMoviesCast(movieId);
        var trailers = _movieRepository.GetMovieTrailers(movieId);

        var movieDetailedModel = new MovieDetailsModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Overview = movie.Overview,
            Rating = movie.Reviews.Any()? movie.Reviews.Average(r =>r.Rating) : 0,
            Price = movie.Price,
            PosterUrl = movie.PosterUrl,
            BackdropUrl = movie.BackdropUrl,
            Genres = movie.MovieGenres.Select(mg => mg.Genre.Name).ToList(),
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            BoxOffice = movie.Revenue,
            Budget = movie.Budget,
            CastModels = casts,
            TrailerModels = trailers
        };
        

        return View(movieDetailedModel);
    }
    
}