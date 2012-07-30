using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MyFavourites.Controllers;
using MyFavourites.Models;
using MyFavouritesTests.Framework;
using MyFavouritesTests.Helpers;
using NUnit.Framework;

namespace MyFavouritesTests.Controllers
{
    [TestFixture]
    class ResearchersControllerTests : ModelTests
    {

        private ResearchersController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ResearchersController();
            _controller.SetFakeControllerContext();
            var user = new Researcher
            {
                Email = "email@tset.com",
                Username = "username"
            };
            user.Save();
        }

        [Test]
        public void CanGetAll()
        {
            // Act
            dynamic result = _controller.Index();

            // Assert
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsInstanceOf<IEnumerable<Researcher>>(result.Model);
        }

        [Test]
        public void CanGetDetails()
        {
            // Act
            dynamic result = _controller.Details(1);

            // Assert
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(1, result.Model.Id);
        }

        [Test]
        public void CanReturnCreateView()
        {
            // Act
            dynamic result = _controller.Create();

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CanCreate()
        {
            // Setup
            var form = new FormCollection
            {
                {"Username",  "pyavari"}
            };
            _controller.ValueProvider = form.ToValueProvider();

            // Act
            dynamic result = _controller.Create(form);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual(2, Researcher.FindAll().Count());
            Assert.AreEqual("pyavari", Researcher.Find(2).Username);
        }


        [Test]
        public void CanRetunEditView()
        {
            // Act
            dynamic result = _controller.Edit(1);

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
            Assert.AreEqual(1, result.Model.Id);
        }

        [Test]
        public void CanUpdate()
        {
            // Setup
            var form = new FormCollection
            {
                {"Email",  "new@email.com"}
            };
            _controller.ValueProvider = form.ToValueProvider();

            // Act
            dynamic result = _controller.Edit(1, form);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("new@email.com", Researcher.Find(1).Email);
        }

        [Test]
        public void CanDelete()
        {
            // Act
            dynamic result = _controller.Delete(1);

            // Assert
            ResetScope();
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual(0, Researcher.FindAll().Count());
        }
    }
}
