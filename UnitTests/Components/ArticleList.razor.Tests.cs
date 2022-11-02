namespace UnitTests.Components
{
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

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Crater Lake in Winter"));
        }
    }
}