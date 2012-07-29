using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFavourites.Models;
using NUnit.Framework;

namespace MyFavouritesTests.Models
{
    [TestFixture]
    public class ResearcherTests
    {
        [Test]
        public void CanCreateAndAssignPropertiesToResearcher()
        {
            // Setup 
            var researcher = new Researcher();

            // Act
            researcher.Name = "Jane Smith";
            researcher.Email = "jsmith@email.org";

            // Assert
            Assert.IsInstanceOf<Researcher>(researcher);
            Assert.AreEqual("Jane Smith", researcher.Name);
            Assert.AreEqual("jsmith@email.org", researcher.Email);
        }

        [Test]
        public void CanAuthorDocuments()
        {
            // Setup
            var researcher = new Researcher {Name = "Payam Yavari"};

            // Act
            researcher.AuthorDocument("The Speed of Sounds");
            researcher.AuthorDocument("The speed of Stones");

            // Assert
            Assert.AreEqual(2, researcher.Documents.Count);
            Assert.AreEqual("The Speed of Sounds", researcher.Documents.First().Title);
            Assert.AreEqual("Payam Yavari", researcher.Documents.First().Author);
            Assert.AreEqual("The speed of Stones", researcher.Documents.Last().Title);
            Assert.AreEqual("Payam Yavari", researcher.Documents.Last().Author);
        }
    }
}
