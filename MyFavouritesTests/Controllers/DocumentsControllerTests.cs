using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MyFavourites.Controllers;
using MyFavourites.Models;
using MyFavouritesTests.Framework;
using NUnit.Framework;

namespace MyFavouritesTests.Controllers
{
    [TestFixture]
    public class DocumentsControllerTests : ModelTests
    {
        private DocumentsController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new DocumentsController();
        }


        [Test]
        public void CanGetAllDocuments()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsInstanceOf<IEnumerable<Document>>(result.Model);
        }

        [Test]
        public void CanGetDetails()
        {
            // Setup
            var document = new Document();
            document.Save();

            // Act
            dynamic result = _controller.Details(document.Id);

            // Assert
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsInstanceOf<Document>(result.Model);
            Assert.AreEqual(document.Id, result.Model.Id);
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
        public void CanCreateDocument()
        {
            // Setup
            var document = new Document();

            // Act
            var result = _controller.Create(document) as 
                RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Details", result.RouteValues["Action"]);
            Assert.AreEqual(document.Id, result.RouteValues["Id"]);
            Assert.AreEqual(1, Document.FindAll().Count());
            
        }
    }
}
