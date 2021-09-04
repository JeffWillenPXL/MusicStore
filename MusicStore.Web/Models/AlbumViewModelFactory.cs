using MusicStore.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.Models
{
    public class AlbumViewModelFactory : IAlbumViewModelFactory
    {
        public AlbumViewModel Create(Album album, Genre genre)
        {
            if (genre == null || album == null)
            {
                throw new ArgumentNullException();
            }
            
            if(album.GenreId != genre.Id)
            {
                throw new ArgumentException();
            }
            return new AlbumViewModel
            {
                Title = album.Title,
                Artist = album.Artist,
                Genre = genre.Name
            };
        }
    }
}
