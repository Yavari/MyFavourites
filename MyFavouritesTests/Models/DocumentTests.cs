using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFavourites.Models;
using MyFavouritesTests.Framework;
using NUnit.Framework;

namespace MyFavouritesTests.Models
{
    [TestFixture]
    public class DocumentTests : ModelTests
    {
        [Test]
        public void CanPersist()
        {
            // Setup
            var document = new Document();
            document.Title = "New Findings";
            document.Author = "Payam Yavari";

            // Act
            document.Save();

            // Assert
            document = Document.Find(document.Id);
            Assert.AreEqual("New Findings", document.Title);
            Assert.AreEqual("Payam Yavari", document.Author);

        }
    }
}
