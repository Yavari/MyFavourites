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
        [Test]
        public void CanGetAllDocuments()
        {
            // Setup
            var controller = new DocumentsController();
            
            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsInstanceOf<IEnumerable<Document>>(result.Model);
        }

    }
}
