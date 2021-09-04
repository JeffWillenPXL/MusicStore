using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using MusicStore.Web;
using MusicStore.Web.Controllers;
using MusicStore.Web.Services;
using NUnit.Framework;
using System;

namespace MusicStore.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _sut;
        private RouteValueDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IFileProvider>();
            mock.Setup(x => x.GetFileBytes(It.IsAny<string>()));
            _sut = new HomeController(mock.Object);
            _dictionary = new RouteValueDictionary();
        }

        [Test]
        [Ignore("Replaced by Index_ReturnsDefaultView")]
        public void Index_ReturnsContentContainingControllerNameAndActionName()
        {
            //Arrange
            _dictionary.Add("controller", "Home");
            _dictionary.Add("action", "Index");
            _sut.ControllerContext.RouteData = new RouteData(_dictionary);

            //Act
            var result = (ContentResult) _sut.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.EqualTo("Home:Index"));
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            //Arrange
            _dictionary.Add("controller", "Home");
            _dictionary.Add("action", "About");
            _sut.ControllerContext.RouteData = new RouteData(_dictionary);

            //Act
            var result = (ContentResult)_sut.About();

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.EqualTo("Home:About"));
        }

        [Test]
        public void Details_ReturnsContentContainingControllerNameActionNameAndParamName()
        {
            //Arrange
            _dictionary.Add("controller", "Home");
            _dictionary.Add("action", "Details");
            _sut.ControllerContext.RouteData = new RouteData(_dictionary);
            int id = new Random().Next();

            //Act
            var result = (ContentResult)_sut.Details(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.EqualTo($"Home:Details:{id}"));
        }

        [Test]
        public void Search_Rock_PermanentRedirect()
        {
            //Arrange
            var genre = "Rock";
            var url = "https://www.youtube.com/watch?v=v2AC41dglnM";


            //Act
            var result = _sut.Search(genre) as RedirectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Permanent);
            Assert.That(result.Url, Is.EqualTo(url));
        }

        [Test]
        public void Search_Jazz_RedirectToAction()
        {
            //Arrange
            var genre = "Jazz";


            //Act
            var result = _sut.Search(genre) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Permanent);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Search_Metal_RedirectToDetailsActionWithARandomId()
        {
            //Arrange
            var genre = "Metal";


            //Act
            var result = _sut.Search(genre) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Permanent);
            Assert.That(result.ActionName, Is.EqualTo("Details"));
            
        }

        [Test]
        public void Search_Classic_ContentOfSiteCssFile()
        {
            //Arrange
            var genre = "Classic";


            //Act
            var result = _sut.Search(genre) as FileContentResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.ContentType, Is.EqualTo("text/css"));
            Assert.IsNotNull(result.FileContents);
            Assert.That(result.FileContents, Is.Empty);
        }

        [Test]
        public void Search_UnknownGenre_ReturnsContentContainingControllerNameActionNameAndGenreParameter()
        {
            //Arrange
            var genre = Guid.NewGuid().ToString();
            _dictionary.Add("controller", "Home");
            _dictionary.Add("action", "Search");
            _sut.ControllerContext.RouteData = new RouteData(_dictionary);


            //Act
            var result = _sut.Search(genre) as ContentResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.EqualTo($"Home:Search:{genre}"));
        }

        [Test]
        public void Index_ReturnsDefaultView()
        {
            //Act
            var result = _sut.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);

        }

    }
}