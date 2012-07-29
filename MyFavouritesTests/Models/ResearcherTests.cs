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
    public class ResearcherTests : ModelTests
    {
        [Test]
        public void CanPersist()
        {
            // Setup 
            var researcher = new Researcher();
            researcher.Name = "Jane Smith";
            researcher.Email = "jsmith@email.org";

            // Act
            researcher.Save();

            // Assert
            var researcherFound = Researcher.FindByName(researcher.Name);
            Assert.IsInstanceOf<Researcher>(researcherFound);
            Assert.AreEqual("Jane Smith", researcherFound.Name);
            Assert.AreEqual("jsmith@email.org", researcherFound.Email);
        }

        [Test]
        public void CanAuthorDocuments()
        {
            // Setup
            var researcher = new Researcher {Name = "Payam Yavari"};
            researcher.AuthorDocument("The Speed of Sounds");
            researcher.AuthorDocument("The speed of Stones");

            // Act
            researcher.Save();

            // Assert
            researcher = Researcher.Find(researcher.Id);
            Assert.AreEqual(2, researcher.Documents.Count);
            Assert.AreEqual("The Speed of Sounds", researcher.Documents.First().Title);
            Assert.AreEqual("Payam Yavari", researcher.Documents.First().AuthorName);
            Assert.AreEqual("The speed of Stones", researcher.Documents.Last().Title);
            Assert.AreEqual("Payam Yavari", researcher.Documents.Last().AuthorName);
        }
    }
}
