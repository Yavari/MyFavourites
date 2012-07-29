using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFavourites.Models;
using NUnit.Framework;

namespace MyFavouritesTests.Models
{
    [TestFixture]
    public class DocumentTests
    {
        [Test]
        public void CanCreateAndAssignProperties()
        {
            // Setup
            var document = new Document();

            // Act
            document.Title = "New Findings";
            document.Author = "Payam Yavari";

            // Assert
            Assert.AreEqual("New Findings", document.Title);
            Assert.AreEqual("Payam Yavari", document.Author);

        }
    }
}
