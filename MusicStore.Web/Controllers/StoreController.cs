using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;

namespace MusicStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;

        public StoreController(IGenreRepository genreRepository, IAlbumRepository albumRepository)
        {
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
        }
        public IActionResult Index()
        {
            var model = _genreRepository.GetAll();
            return View(model);
        }

        public IActionResult Browse(int genreId)
        {
            var model = _albumRepository.GetAlbumsByGenre(genreId);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.Genre = _genreRepository.GetById(genreId).Name;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _albumRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
