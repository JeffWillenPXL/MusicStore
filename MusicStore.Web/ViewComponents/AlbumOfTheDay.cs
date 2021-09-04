using Microsoft.AspNetCore.Mvc;
using MusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.ViewComponents
{
    public class AlbumOfTheDay: ViewComponent
    {
        private readonly AlbumViewModel _albumViewModel;

        public AlbumOfTheDay()
        {
            _albumViewModel = new AlbumViewModel
            {
                Artist = "Lady Gaga",
                Genre = "Pop",
                Title = "Pokerface"
            };


        }

        public IViewComponentResult Invoke()
        {
            return View("Default",_albumViewModel);
        }
    }
}
