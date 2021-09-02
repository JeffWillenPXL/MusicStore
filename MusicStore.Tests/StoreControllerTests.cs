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
        private readonly IReadOnlyList<Genre> _dummyGenres = new List<Genre>
        {
            new Genre
            {
                Id = 1,
                Name = "Rock"
            },

            new Genre
            {
                Id = 2,
                Name = "Classic"
            }
        };
        [SetUp]
        public void Setup()
        {
            var genreRepoMock = new Mock<IGenreRepository>();
            genreRepoMock.Setup(x => x.GetAll()).Returns(_dummyGenres);
            _sut = new StoreController(genreRepoMock.Object);
        }

        [Test]
        public void Index_ShowsListOfMusicGenres()
        {
            //Act
            var result = _sut.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.That(result.Model, Is.EqualTo(_dummyGenres));
           
            

        }
    }
}
