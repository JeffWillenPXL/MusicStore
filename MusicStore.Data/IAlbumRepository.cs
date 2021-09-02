using MusicStore.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Data
{
    public interface IAlbumRepository
    {
        IReadOnlyList<Album> GetAlbumsByGenre(int genreId);
        Album GetById(int id);
    }
}
