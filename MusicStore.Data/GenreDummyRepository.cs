using MusicStore.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Data
{
    public class GenreDummyRepository : IGenreRepository
    {

        private static readonly IReadOnlyList<Genre> _genres = new List<Genre>
        {
            new Genre
            {
                Id = 1,
                Name = "Metal"
            },

            new Genre
            {
                Id = 2,
                Name = "Pop"
            },

            new Genre
            {
                Id = 3,
                Name = "Jazz"
            }
        };

        public IReadOnlyList<Genre> GetAll()
        {
            return _genres;
        }
    }
}
