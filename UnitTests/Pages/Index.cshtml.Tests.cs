namespace UnitTests.Pages
{
    using System.Linq;
    using ContosoCrafts.WebSite.Pages;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class for Index page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // Data field to hold Index page for this test
        public static IndexModel pageModel;

        /// <summary>
        /// Set up test prior to execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ArticleService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test valid result for OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Articles()
        {
            // Arrange
            _ = pageModel.Articles;
            _ = pageModel.ArticleService;

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Articles.ToList().Any());
        }
        #endregion OnGet
    }
}
