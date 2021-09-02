using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicStore.Data;
using MusicStore.Data.DomainClasses;
using MusicStore.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Tests
{
    [TestFixture]
    public class StoreControllerTests
    {
        private StoreController _sut;
        private Mock<IGenreRepository> _genreRepoMock;
        private Mock<IAlbumRepository> _albumRepoMock;


        private readonly IReadOnlyList<Genre> _dummyGenres = new List<Genre>();
        private readonly IReadOnlyList<Album> _dummyAlbums = new List<Album>();
        private readonly Album _dummyAlbum = new Album();
        
        [SetUp]
        public void Setup()
        {
            _genreRepoMock = new Mock<IGenreRepository>();
            _albumRepoMock = new Mock<IAlbumRepository>();
        }

        [Test]
        public void Index_ShowsListOfMusicGenres()
        {
            //Arrange
            _genreRepoMock.Setup(x => x.GetAll()).Returns(_dummyGenres);
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);

            //Act
            var result = _sut.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.That(result.Model, Is.SameAs(_dummyGenres));
           
        }
        [Test]
        public void Browse_ShowsAlbumsOfGenre()
        {
            //Arrange
            var dummyGenre = new Genre
            {
                Id = 1,
                Name = "Test"
            };
            
            _genreRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(dummyGenre);
            _albumRepoMock.Setup(x => x.GetAlbumsByGenre(It.IsAny<int>())).Returns(_dummyAlbums);
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);


            //Act
            var id = new Random().Next();
            var result = _sut.Browse(id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.That(result.Model, Is.SameAs(_dummyAlbums));
            Assert.That(_sut.ViewBag.Genre, Is.EqualTo(dummyGenre.Name));
            
        }
        [Test]
        public void Browse_InvalidGenreId_ReturnsNotFound()
        {
            //Arrange
            _albumRepoMock.Setup(x => x.GetAlbumsByGenre(It.IsAny<int>()));
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);

            //Act
            var id = new Random().Next();
            var result = _sut.Browse(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void Details_ShowsDetailsOfAlbum()
        {
            //Arrange
            _albumRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(_dummyAlbum);
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);

            //Act
            var id = new Random().Next();
            var result = _sut.Details(id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.That(result.Model, Is.SameAs(_dummyAlbum));
        }

        [Test]
        public void Details_InvalidId_ReturnNotFound()
        {
            //Arrange
            _albumRepoMock.Setup(x => x.GetById(It.IsAny<int>()));
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);

            //Act
            var id = new Random().Next();
            var result = _sut.Details(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }


    }
}
