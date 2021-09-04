using MusicStore.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.Models
{
    public interface IAlbumViewModelFactory
    {
        AlbumViewModel Create(Album album, Genre genre);
    }
}
