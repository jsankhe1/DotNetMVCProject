using Core.Contracts.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesMVCProject.Views.Components;

public class GenreMenuViewComponent: ViewComponent
{
    private readonly IGenreRepository _genreRepository;

    public GenreMenuViewComponent(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public IViewComponentResult Invoke()
    {
        var genres = _genreRepository.GetAll().ToList();

        int selectedGenre = 0;
        //  read genreId from query string (if set by pagination or MoviesByGenre)
        if (int.TryParse(HttpContext.Request.Query["genreId"], out int id))
        {
            selectedGenre = id;
        }
        
        // Create a SelectList using the selectedGenre value
        var selectList = new SelectList(genres, "Id", "Name", selectedGenre == 0 ? null : selectedGenre);
        return View(selectList);
    }
}