using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MyFavouritesTests.Models
{
    [TestFixture]
    public class ResearcherTests
    {
        [Test]
        public void CanCreateAResearcher()
        {
            //setup/act
            var researcher = new Researcher();

            //Assert
            Assert.IsInstanceOf<Researcher>(researcher);
        }
    }
}
