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
    public class DocumentsControllerTests : ModelTests
    {
        private DocumentsController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new DocumentsController();
            _controller.SetFakeControllerContext();
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
            var form = new FormCollection
            {
                {"Title", "Title"},
                {"Text", "Text"}
            };
            _controller.ValueProvider = form.ToValueProvider();

            // Act
            var result = _controller.Create(form) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Details", result.RouteValues["Action"]);
            Assert.AreEqual(1, result.RouteValues["Id"]);
            Assert.AreEqual(1, Document.FindAll().Count());
        }

        [Test]
        public void CanRetunEditView()
        {
            // Setup
            var document = new Document();
            document.Save();

            //Act
            dynamic result = _controller.Edit(document.Id);

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
            Assert.AreEqual(document, result.Model);
        }

        [Test]
        public void CanUpdateDocument()
        {
            // Setup
            var document = new Document();
            document.Save();
            var form = new FormCollection
            {
                {"Title", "New Title"},
                {"Text", "New Text"}
            };
            _controller.ValueProvider = form.ToValueProvider();

            // Act
            dynamic result = _controller.Edit(document.Id, form);

            // Assert
            Assert.AreEqual("Details", result.RouteValues["Action"]);
            Assert.AreEqual(document.Id, result.RouteValues["Id"]);
            document = Document.Find(document.Id);
            Assert.AreEqual("New Title", document.Title);
            Assert.AreEqual("New Text", document.Text);
        }

        [Test]
        public void CanDelete()
        {
            // Setup
            var document = new Document();
            document.Save();

            // Act
            dynamic result = _controller.Delete(document.Id);

            // Assert
            ResetScope();
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual(0, Document.FindAll().Count());
        }
    }
}
