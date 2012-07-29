using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using MyFavourites.Infrastructure;
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
            researcher.Username = "jsmith";

            // Act
            researcher.Save();

            // Assert
            researcher = Researcher.FindByUsername(researcher.Username);
            Assert.IsInstanceOf<Researcher>(researcher);
            Assert.AreEqual("Jane Smith", researcher.Name);
            Assert.AreEqual("jsmith@email.org", researcher.Email);
            Assert.AreEqual("jsmith", researcher.Username);
        }

        [Test]
        public void CanAuthorDocuments()
        {
            // Setup
            var researcher = new Researcher {Name = "Payam Yavari"};
            researcher.AuthorDocument("The Speed of Sounds", "...");
            researcher.AuthorDocument("The speed of Stones", "...");

            // Act
            researcher.Save();
            ScopeManagement.ResetScope();

            // Assert
            researcher = Researcher.Find(researcher.Id);
            Assert.AreEqual(2, researcher.Documents.Count);

            var document = researcher.Documents.First();
            Assert.AreEqual("The Speed of Sounds", document.Title);
            Assert.AreEqual("...", document.Text);
            Assert.AreEqual("Payam Yavari", document.AuthorName);

            document = researcher.Documents.Last();
            Assert.AreEqual("The speed of Stones", document.Title);
            Assert.AreEqual("...", document.Text);
            Assert.AreEqual("Payam Yavari", document.AuthorName);  
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfNotFound()
        {
            var exception = Assert.Throws<NotFoundException>(() => Researcher.FindByUsername("jsmith"));
            Assert.AreEqual("'jsmith' not found", exception.Message);
        }

        [Test]
        public void CanAddFavourite()
        {
            // Setup
            var researcher = new Researcher();
            researcher.AuthorDocument("New document", "...");
            researcher.Save();

            // Act
            researcher.AddFavourite(researcher.Documents.First().Id);
            researcher.AddFavourite(researcher.Documents.First().Id);

            // Assert
            researcher = Researcher.Find(researcher.Id);
            Assert.AreEqual(1, researcher.Favourites.Count);
        }

        [Test]
        public void CanRemoveFavourite()
        {
            // Setup
            var researcher = new Researcher();
            researcher.AuthorDocument("Title", "...");
            researcher.Save();
            researcher.AddFavourite(researcher.Documents.First().Id);

            // Act
            Researcher.Find(researcher.Id).RemoveFavourite(1);

            // Assert
            Assert.AreEqual(0, Researcher.Find(researcher.Id).Favourites.Count);
            Assert.AreEqual(0, Favourite.FindAll().Count());
        }
    }
}
