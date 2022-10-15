using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    public class ArticleListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ArticleList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileArticleService>(TestHelper.ArticleService);

            // Act
            var page = RenderComponent<ArticleList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("The Quantified Cactus: An Easy Plant Soil Moisture Sensor"));
        }
    }
}