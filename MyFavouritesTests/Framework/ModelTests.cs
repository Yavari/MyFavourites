using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using log4net.Config;
using NUnit.Framework;

namespace MyFavouritesTests.Framework
{
    public class ModelTests
    {
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            if (ActiveRecordStarter.IsInitialized) return;
            
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            XmlConfigurator.Configure();
            ActiveRecordStarter.Initialize(Assembly.Load("MyFavourites"), source);

        }

        [SetUp]
        public void SetUp()
        {
            ActiveRecordStarter.CreateSchema();
        }

        [TearDown]
        public void TearDownFixture()
        {
            ActiveRecordStarter.DropSchema(); 
        }
    }
}