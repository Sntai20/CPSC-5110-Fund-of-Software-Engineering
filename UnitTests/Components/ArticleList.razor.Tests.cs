namespace UnitTests.Components
{
    using System.Linq;
    using Bunit;
    using ContosoCrafts.WebSite.Components;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;

    /// <summary>
    /// Article list test set.
    /// </summary>
    public class ArticleListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Initialize the test set.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Test for returning list of articles. 
        /// </summary>
        [Test]
        public void ArticleList_Default_Should_Return_Content()
        {
            // Arrange
            _ = Services.AddSingleton<JsonFileArticleService>(TestHelper.ArticleService);

            // Act
            var page = RenderComponent<ArticleList>();

            // Get the Cards returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Crater Lake in Winter"));
        }

        /// <summary>
        /// Unit test to validate Select Article click
        /// </summary>
        [Test]
        public void SelectArticle_Valid_ID_jenlooper_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileArticleService>(TestHelper.ArticleService);
            var id = "MoreInfoButton_jenlooper-cactus";
            var page = RenderComponent<ArticleList>();

            // Find More Info button specific to id
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Store markup for Assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Most days in November through May"));
        }
    }
}
