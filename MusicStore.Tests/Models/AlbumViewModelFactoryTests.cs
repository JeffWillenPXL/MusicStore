using Moq;
using MusicStore.Data;
using MusicStore.Data.DomainClasses;
using MusicStore.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Tests.Models
{
    [TestFixture]
    public class AlbumViewModelFactoryTests
    {
       
        private IAlbumViewModelFactory _sut;
        private Album _album;
        private Genre _genre;
        [SetUp]
        public void SetUp()
        {
           
            _sut = new AlbumViewModelFactory();
        }

        [Test]
        public void Create_ValidAlbumAndValidGenre_CorrectlyMapped()
        {
            //Arrange
            _album = new Album
            {
                Id = 1,
                Artist = "test",
                GenreId = 1,
                Title = "test"
            };
            _genre = new Genre
            {
                Id = 1,
                Name = "test"
            };

            //Act
            var result = _sut.Create(_album, _genre);

            //Assert
            Assert.That(result, Is.TypeOf<AlbumViewModel>());
        }
        [Test]
        public void Create_MissingGenre_ThrowsException()
        {
            //Arrange
            _album = new Album
            {
                Id = 1,
                Artist = "test",
                GenreId = 1,
                Title = "test"
            };

            //Assert

            Assert.That(() => _sut.Create(_album, null), Throws.InstanceOf<ArgumentNullException>());
            

        }

        [Test]
        public void Create_MissingAlbum_ThrowsException()
        {
            //Arrange
            _genre = new Genre
            {
                Id = 1,
                Name = "test"
            };

            //Assert

            Assert.That(() => _sut.Create(null, _genre), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Create_MisMatchBetweenAlbumAndGenre_ThrowsException()
        {
            //Arrange
            _album = new Album
            {
                Id = 1,
                Artist = "test",
                GenreId = 2,
                Title = "test"
            };
            _genre = new Genre
            {
                Id = 1,
                Name = "test"
            };

            //Assert

            Assert.That(() => _sut.Create(_album, _genre), Throws.InstanceOf<ArgumentException>());
        }
    }
}
