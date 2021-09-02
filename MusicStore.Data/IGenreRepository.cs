using MusicStore.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Data
{
    public interface IGenreRepository
    {
        IReadOnlyList<Genre> GetAll();
    }
}
