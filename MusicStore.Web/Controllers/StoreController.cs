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

        public StoreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IActionResult Index()
        {
            var model = _genreRepository.GetAll();
            return View(model);
        }
    }
}
