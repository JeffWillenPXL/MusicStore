using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MusicStore.Web.Controllers;
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
            _sut = new HomeController();
            _dictionary = new RouteValueDictionary();
        }

        [Test]
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
    }
}