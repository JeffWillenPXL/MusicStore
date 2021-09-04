using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Web.Models;

namespace MusicStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumViewModelFactory _albumViewModelFactory;

        public StoreController(IGenreRepository genreRepository, IAlbumRepository albumRepository, IAlbumViewModelFactory albumViewModelFactory)
        {
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
            _albumViewModelFactory = albumViewModelFactory;
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
            
            
            var album = _albumRepository.GetById(id);
            if (album == null)
            {
                return NotFound();
            }
            var genre = _genreRepository.GetById(album.GenreId);
            var albumViewModel = _albumViewModelFactory.Create(album, genre);
            

            return View(albumViewModel);
        }
    }
}
