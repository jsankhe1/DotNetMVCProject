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
        var selectList = new SelectList(genres, "Id", "Name");
        return View(selectList);
    }
}